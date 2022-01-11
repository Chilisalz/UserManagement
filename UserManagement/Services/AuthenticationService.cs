using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.DataAccessLayer;
using UserManagementService.Dtos;
using UserManagementService.Dtos.ChiliUser;
using UserManagementService.Exceptions;
using UserManagementService.Extensions;
using UserManagementService.Models;
using UserManagementService.Options;
using UserManagementService.Services.Contracts;

namespace UserManagementService.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JWTSettings _jwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly UserManagementContext _context;
        private readonly IMapper _mapper;
        public AuthenticationService(JWTSettings jwtSettings, TokenValidationParameters tokenValidationParameters, UserManagementContext context, IMapper mapper)
        {
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
            _context = context;
            _mapper = mapper;
        }
        public async Task<ChiliUserDto> RegisterAsync(UserRegistrationDto request)
        {
            ChiliUser existingUser = await _context.Users.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {                
                throw new EmailAlreadyTakenException($"Email {request.Email} is already used");
            }

            existingUser = await _context.Users.FindByUsernameAsync(request.UserName);
            if (existingUser != null)
            {
                throw new UsernameAlreadyTakenException($"Username {request.UserName} is already used");
            }

            SecurityQuestion SecretQuestion = await _context.SecurityQuestions.FirstOrDefaultAsync(x => x.Id == request.SecretQuestion);
            if (SecretQuestion == null)
            {
                throw new SecretQuestionNotFoundException($"Secretquestion with id {request.SecretQuestion} not found.");
            }

            ChiliUser newUser = new()
            {
                Email = request.Email,
                UserName = request.UserName,
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                SecretQuestionId = request.SecretQuestion
            };
            PasswordHasher<ChiliUser> passwordHasher = new();
            newUser.PasswordHash = passwordHasher.HashPassword(newUser, request.Password);
            newUser.SecretAnswer = passwordHasher.HashPassword(newUser, request.SecretAnswer);
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return _mapper.Map<ChiliUserDto>(newUser);
        }
        public async Task<AuthenticationDto> LoginAsync(UserLoginDto request)
        {
            ChiliUser user = await _context.Users.FindByUsernameAsync(request.UserName);

            if (user == null)
            {
                user = await _context.Users.FindByEmailAsync(request.UserName);
                if (user == null)
                    throw new UserNotFoundException($"User with username or email {request.UserName} not found");
            }
            PasswordHasher<ChiliUser> passwordHasher = new();
            PasswordVerificationResult userHasValidPassword = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

            if (userHasValidPassword == PasswordVerificationResult.Failed)
                throw new InvalidPasswordException("User/Password combination is wrong");

            return await GenerateAuthenticationResultForUserAsync(user);
        }
        public async Task<AuthenticationDto> VerifyTokenAsync(string token, string refreshToken)
        {
            ClaimsPrincipal validatedToken = GetPrincipalFromToken(token);
            if (validatedToken == null)
                throw new InvalidTokenException("Invalid token");
            long expiryDateUnix = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            DateTime expiryDateUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            //if (expiryDateUtc > DateTime.UtcNow)
            //throw new TokenHasntExpiredException("This token hasn't expired yet");

            string jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            RefreshToken storedRefreshToken = await _context.RefreshTokens.SingleOrDefaultAsync(x => x.Token.ToString() == refreshToken);

            if (storedRefreshToken == null)
                throw new RefreshTokenNotFoundException("This refresh token does not exist");

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
                throw new RefreshTokenHasExpiredException("This refresh token has expired");

            if (storedRefreshToken.Invalidated)
                throw new InvalidatedRefreshTokenException("this refresh token has been invalidated.");

            if (storedRefreshToken.Used)
                throw new RefreshTokenAlreadyUsedException("This refresh token has already been used");

            if (storedRefreshToken.JwtId != jti)
                throw new InvalidJwtException("This refresh token does not match this JWT");

            storedRefreshToken.Used = true;
            _context.RefreshTokens.Update(storedRefreshToken);
            await _context.SaveChangesAsync();

            var user = await _context.Users.FindByIdAsync(Guid.Parse(validatedToken.Claims.Single(x => x.Type == "id").Value));

            return await GenerateAuthenticationResultForUserAsync(user);
        }
        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                    return null;
                return principal;
            }
            catch
            {
                return null;
            }
        }
        private static bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken)
                     && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }
        private async Task<AuthenticationDto> GenerateAuthenticationResultForUserAsync(ChiliUser newUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            _context.Entry(newUser).Reference(c => c.Role).Load();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id.ToString()),
                    new Claim("userrole", newUser.Role.Rolename),
                    new Claim("secretQuestionId", newUser.SecretQuestionId.ToString())
                }),
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                UserId = newUser.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6)
            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return new AuthenticationDto()
            {
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token.ToString()
            };
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.DataAccessLayer;
using UserManagementService.Extensions;
using UserManagementService.Models;
using UserManagementService.Models.ServiceResults;
using UserManagementService.Options;
using UserManagementService.Extensions;

namespace UserManagementService.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JWTSettings _jwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly UserManagementContext _context;
        public AuthenticationService(JWTSettings jwtSettings, TokenValidationParameters tokenValidationParameters, UserManagementContext context)
        {
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
            _context = context;
        }
        public async Task<AuthenticationResult> RegisterAsync(UserRegistrationRequest request)
        {
            var existingUser = await _context.Users.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this email address already exists" }
                };
            }
            else
            {
                existingUser = await _context.Users.FindByUsernameAsync(request.UserName);
                if (existingUser != null)
                {
                    return new AuthenticationResult()
                    {
                        Errors = new[] { "User with this Username already exists" }
                    };
                }
            }

            var SecretQuestion = await _context.SecurityQuestions.FirstOrDefaultAsync(x => x.Id == request.SecretQuestion);
            if (SecretQuestion == null)
                return new AuthenticationResult()
                {
                    Errors = new[] { "Secretquestion not found" }
                };

            var newUser = new ChiliUser
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
            var createdUser = await _context.Users.AddAsync(newUser);

            if (!(createdUser.State == EntityState.Added))
                return new AuthenticationResult
                {
                    Errors = new[] { "Error while creating" }
                };

            return await GenerateAuthenticationResultForUserAsync(newUser);
        }
        public async Task<AuthenticationResult> LoginAsync(string userName, string password)
        {
            ChiliUser user = await _context.Users.FindByUsernameAsync(userName);            

            if (user == null)
            {
                user = await _context.Users.FindByEmailAsync(userName);
                if (user == null)
                {
                    return new AuthenticationResult
                    {
                        Errors = new[] { "User does not exist" }
                    };
                }
            }
            var passwordHasher = new PasswordHasher<ChiliUser>();
            var userHasValidPassword = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);


            if (userHasValidPassword == PasswordVerificationResult.Failed)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User/Password combination is wrong" }
                };
            }


            return await GenerateAuthenticationResultForUserAsync(user);
        }
        public VerificationResult VerifyToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                _ = tokenHandler.ValidateToken(token, _tokenValidationParameters, out SecurityToken validatedToken);
                return new VerificationResult()
                {
                    Verified = true
                };
            }
            catch (Exception)
            {
                return new VerificationResult()
                {
                    Verified = false,
                    Errors = new[] { "Invalid Token" }
                };
            }
        }
        public async Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
        {
            var validatedToken = GetPrincipalFromToken(token);
            if (validatedToken == null)
                return new AuthenticationResult()
                {
                    Errors = new[] { "Invalid Token" }
                };
            var expiryDateUnix = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expiryDateUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            if (expiryDateUtc > DateTime.UtcNow)
                return new AuthenticationResult()
                {
                    Errors = new[] { "This Token hasn't expired yet" }
                };

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            var storedRefreshToken = await _context.RefreshTokens.SingleOrDefaultAsync(x => x.Token.ToString() == refreshToken);

            if (storedRefreshToken == null)
                return new AuthenticationResult()
                {
                    Errors = new[] { "This refresh token does not exist" }
                };

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
                return new AuthenticationResult()
                {
                    Errors = new[] { "This refresh token has expired" }
                };

            if (storedRefreshToken.Invalidated)
                return new AuthenticationResult()
                {
                    Errors = new[] { "This refresh token has been invalidated" }
                };

            if (storedRefreshToken.Used)
                return new AuthenticationResult()
                {
                    Errors = new[] { "This refresh token has been used" }
                };

            if (storedRefreshToken.JwtId != jti)
                return new AuthenticationResult()
                {
                    Errors = new[] { "This refresh token does not match this JWT" }
                };

            storedRefreshToken.Used = true;
            _context.RefreshTokens.Update(storedRefreshToken);
            await _context.SaveChangesAsync();

            var user = await _context.Users.FindAsync(validatedToken.Claims.Single(x => x.Type == "id").Value);

            return await GenerateAuthenticationResultForUserAsync(user);
        }
        public async Task<List<SecurityQuestion>> GetAllSecurityQuestionsAsync()
        {
            return await _context.SecurityQuestions.ToListAsync();
        }
        public async Task<SecurityQuestion> GetSecurityQuestionOfUserAsync(Guid id)
        {
            return await _context.SecurityQuestions.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<VerificationResult> ValidateSecretAnswerAsync(ValidateSecretAnswerRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null)
                return new VerificationResult()
                {
                    Verified = false,
                    Errors = new[] { "User not found" }
                };
            PasswordHasher<ChiliUser> passwordHasher = new();
            if (passwordHasher.VerifyHashedPassword(user, user.SecretAnswer, request.SecretAnswer) == PasswordVerificationResult.Failed)
                return new VerificationResult()
                {
                    Verified = false,
                    Errors = new[] { "Wrong answer" }
                };
            return new VerificationResult()
            {
                Verified = true
            };
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
        private async Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(ChiliUser newUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id.ToString())
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

            return new AuthenticationResult()
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token.ToString()
            };
        }
    }
}

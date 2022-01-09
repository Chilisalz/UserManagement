using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UserManagementService.DataAccessLayer;
using UserManagementService.Dtos;
using UserManagementService.Dtos.ChiliUser;
using UserManagementService.Exceptions;
using UserManagementService.Extensions;
using UserManagementService.Models;
using UserManagementService.Services.Contracts;

namespace UserManagementService.Services
{
    public class UserService : IUserService
    {
        private readonly UserManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public UserService(UserManagementContext context, IMapper mapper, ILogger<UserService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            ChiliUser delUser = await _context.Users.FindByIdAsync(id);
            if (delUser is null)
                throw new UserNotFoundException($"User with id {id} not found");

            _ = _context.Users.Remove(delUser);
            _ = await _context.SaveChangesAsync();
        }
        public async Task<GetUsersResultDto> GetAllUsersAsync(int page)
        {
            List<ChiliUser> users = await _context.Users.Include(u => u.SecretQuestion).Include(u => u.Role).Skip((page - 1) * 10).Take(10).ToListAsync();
            return new GetUsersResultDto()
            {
                Users = _mapper.Map<List<ChiliUserAdminViewDto>>(users),
                Pagination = new Pagination(page, users.Count, _context.Users.Count())
            };
        }
        public async Task<ChiliUserDto> GetChiliUserByIdAsync(Guid id)
        {
            ChiliUser user = await _context.Users.Include(u => u.SecretQuestion).Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
            return user == null ? throw new UserNotFoundException($"User with id {id} not found") : _mapper.Map<ChiliUserDto>(user);
        }
        public async Task<ChiliUserDto> UpdateUserAsync(Guid id, ChiliUserDto request)
        {
            ChiliUser user = await _context.Users.Include(u => u.SecretQuestion).Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                throw new UserNotFoundException();
            if (await _context.Users.AnyAsync(x => x.UserName == request.UserName && x.Id != id))
                throw new UsernameAlreadyTakenException($"Username {request.UserName} is already used");
            if (await _context.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
                throw new EmailAlreadyTakenException($"Email {request.Email} is already used");

            foreach (PropertyInfo requestUserProperty in request.GetType().GetProperties())
            {
                var value = requestUserProperty.GetValue(request);

                if (value != null)
                {
                    if (value is Guid g && g == Guid.Empty)
                        continue;

                    user.GetType()
                        .GetProperty(requestUserProperty.Name)
                        .SetValue(user, Convert.ChangeType(value, requestUserProperty.PropertyType), null); ;
                }
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<ChiliUserDto>(user);
        }
        public async Task ChangePasswordAsync(Guid id, ChangePasswordDto request)
        {
            ChiliUser user = await _context.Users.FindByIdAsync(id);
            if (user == null)
                throw new UserNotFoundException($"User with id {id} not found");
            PasswordHasher<ChiliUser> passwordHasher = new();
            if (passwordHasher.VerifyHashedPassword(user, user.SecretAnswer, request.SecretAnswer) == PasswordVerificationResult.Failed)
                throw new InvalidPasswordException("Invalid password.");

            user.PasswordHash = passwordHasher.HashPassword(user, request.NewPassword);
            await _context.SaveChangesAsync();
        }
        public async Task<List<SecurityQuestion>> GetAllSecurityQuestionsAsync()
        {
            return await _context.SecurityQuestions.ToListAsync();
        }
        public async Task<SecurityQuestion> GetSecurityQuestionOfUserAsync(string email)
        {
            ChiliUser user = await _context.Users.Include(u => u.SecretQuestion).FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                throw new UserNotFoundException($"User with email {email} not found");
            return user.SecretQuestion;
        }
        public async Task ValidateSecretAnswerAsync(ValidateSecretAnswerDto request)
        {
            ChiliUser user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null)
                throw new UserNotFoundException($"User with id {request.UserId} not found");
            PasswordHasher<ChiliUser> passwordHasher = new();
            if (passwordHasher.VerifyHashedPassword(user, user.SecretAnswer, request.SecretAnswer) == PasswordVerificationResult.Failed)
                throw new WrongSecretAnswerException($"Wrong secret answer");
        }

        public List<ChiliUserNameDto> MapChiliUser(List<Guid> request)
        {
            var users = _context.Users.Where(u => request.Contains(u.Id));
            return _mapper.Map<List<ChiliUserNameDto>>(users);
        }
    }
}

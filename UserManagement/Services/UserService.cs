using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.DataAccessLayer;
using UserManagementService.Extensions;
using UserManagementService.Models;
using UserManagementService.Models.ServiceResults;

namespace UserManagementService.Services
{
    public class UserService : IUserService
    {
        private readonly UserManagementContext _context;
        public UserService(UserManagementContext context)
        {
            _context = context;
        }

        public async Task<DeleteResult> DeleteUserAsync(Guid id)
        {
            var delUser = await _context.Users.FindByIdAsync(id);
            if (delUser == null)
                return new DeleteResult()
                {
                    UserId = id,
                    Success = false,
                    Errors = new[] { $"User not found" },
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            _context.Users.Remove(delUser);
            await _context.SaveChangesAsync();
            return new DeleteResult()
            {
                Success = true,
                HttpStatusCode = HttpStatusCode.OK
            };
        }
        public async Task<List<ChiliUser>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<ChiliUser> GetChiliUserByIdAsync(Guid id)
        {
            return await _context.Users.FindByIdAsync(id);
        }
        public async Task<ChiliUserUpdateResult> UpdateUserAsync(Guid id, ChiliUserRequest request)
        {
            var user = await _context.Users.FindByIdAsync(id);
            if (user == null)
                return new ChiliUserUpdateResult()
                {
                    Success = false,
                    Errors = new[] { "User not found" },
                    HttpStatusCode = HttpStatusCode.NotFound,
                    User = null
                };
            if (await _context.Users.AnyAsync(x => x.UserName == request.Username && x.Id != id))
                return new ChiliUserUpdateResult()
                {
                    Success = false,
                    Errors = new[] { "Username is already used" },
                    HttpStatusCode = HttpStatusCode.Conflict,
                    User = null
                };
            if (await _context.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
                return new ChiliUserUpdateResult()
                {
                    Success = false,
                    Errors = new[] { "Email is already used" },
                    HttpStatusCode = HttpStatusCode.Conflict,
                    User = null
                };

            foreach (var requestUserProperty in request.GetType().GetProperties())
            {
                var value = requestUserProperty.GetValue(request);
                if (value != null)
                {
                    var userProperty = user.GetType().GetProperty(requestUserProperty.Name);
                    userProperty.SetValue(user, Convert.ChangeType(value, requestUserProperty.PropertyType), null);
                }
            }

            await _context.SaveChangesAsync();

            return new ChiliUserUpdateResult()
            {
                Success = true,
                HttpStatusCode = HttpStatusCode.OK,
                User = user
            };
        }
        public async Task<ChangePasswordResult> ChangePasswordAsync(Guid id, ChangePasswordRequest request)
        {
            var user = await _context.Users.FindByIdAsync(id);
            if (user == null)
                return new ChangePasswordResult()
                {
                    UserId = id,
                    Success = false,
                    Errors = new[] { "User not found" },
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            PasswordHasher<ChiliUser> passwordHasher = new();
            if (passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.OldPassword) == PasswordVerificationResult.Failed)
                return new ChangePasswordResult()
                {
                    UserId = id,
                    Success = false,
                    Errors = new[] { "Wrong password" },
                    HttpStatusCode = HttpStatusCode.NotFound
                };

            user.PasswordHash = passwordHasher.HashPassword(user, request.NewPassword);
            await _context.SaveChangesAsync();

            return new ChangePasswordResult()
            {
                HttpStatusCode = HttpStatusCode.OK,
                Success = true,
                UserId = id
            };
        }
    }
}

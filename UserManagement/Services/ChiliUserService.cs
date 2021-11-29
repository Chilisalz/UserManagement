using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.DataAccessLayer;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public class ChiliUserService : IChiliUserService
    {
        private readonly UserManagementContext _context;
        public ChiliUserService(UserManagementContext context)
        {
            _context = context;
        }

        public async Task<IdentityResult> DeleteUserAsync(Guid id)
        {
            var delUser = await _context.Users.FindAsync(id);
            _context.Users.Remove(delUser);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<List<ChiliUser>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ChiliUser> GetChiliUserByIdAsync(Guid id)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ChiliUserUpdateResult> UpdateUserAsync(Guid id, ChiliUserRequest request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return new ChiliUserUpdateResult()
                {
                    Succeeded = false,
                    Errors = new[] { "User not found" },
                    HttpStatusCode = HttpStatusCode.NotFound,
                    User = null
                };
            if (await _context.Users.AnyAsync(x => x.UserName == request.Username && x.Id != id))
                return new ChiliUserUpdateResult()
                {
                    Succeeded = false,
                    Errors = new[] { "Username is already used" },
                    HttpStatusCode = HttpStatusCode.Conflict,
                    User = null
                };
            if (await _context.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
                return new ChiliUserUpdateResult()
                {
                    Succeeded = false,
                    Errors = new[] { "Email is already used" },
                    HttpStatusCode = HttpStatusCode.Conflict,
                    User = null
                };

            user.UserName = request.Username;
            user.Email = request.Email;

            //await _context.Users.UpdateAsync(user);
            await _context.SaveChangesAsync();

            return new ChiliUserUpdateResult()
            {
                Succeeded = true,
                HttpStatusCode = HttpStatusCode.OK,
                User = user
            };
        }
    }
}

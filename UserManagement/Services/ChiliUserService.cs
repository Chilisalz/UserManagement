using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public class ChiliUserService : IChiliUserService
    {
        private readonly UserManager<ChiliUser> _userManager;
        public ChiliUserService(UserManager<ChiliUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> DeleteUser(Guid id)
        {
            var delUser = await _userManager.FindByIdAsync(id.ToString());
            return await _userManager.DeleteAsync(delUser);
        }

        public async Task<List<ChiliUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ChiliUser> GetChiliUserById(Guid id)
        {
            return await _userManager.Users.SingleOrDefaultAsync(x => x.Id == id.ToString());
        }

        public async Task<ChiliUserUpdateResult> UpdateUserAsync(Guid id, ChiliUserRequest request)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == id.ToString());
            if (user == null)
                return new ChiliUserUpdateResult()
                {
                    Succeeded = false,
                    Errors = new[] { "User not found" },
                    HttpStatusCode = HttpStatusCode.NotFound,
                    User = null
                };
            if (await _userManager.Users.AnyAsync(x => x.UserName == request.Username && x.Id != id.ToString()))
                return new ChiliUserUpdateResult()
                {
                    Succeeded = false,
                    Errors = new[] { "Username is already used" },
                    HttpStatusCode = HttpStatusCode.Conflict,
                    User = null
                };
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id.ToString()))
                return new ChiliUserUpdateResult()
                {
                    Succeeded = false,
                    Errors = new[] { "Email is already used" },
                    HttpStatusCode = HttpStatusCode.Conflict,
                    User = null
                };

            user.UserName = request.Username;
            user.Email = request.Email;

            await _userManager.UpdateAsync(user);

            return new ChiliUserUpdateResult()
            {
                Succeeded=true,
                HttpStatusCode = HttpStatusCode.OK,
                User = user
            };
        }
    }
}

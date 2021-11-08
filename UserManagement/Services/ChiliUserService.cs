using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<ChiliUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ChiliUser> GetChiliUserById(Guid id)
        {
            return await _userManager.Users.SingleOrDefaultAsync(x => x.Id == id.ToString());
        }
    }
}

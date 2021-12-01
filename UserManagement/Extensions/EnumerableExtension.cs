using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using UserManagementService.Models;

namespace UserManagementService.Extensions
{
    public static class EnumerableExtension
    {
        public static async Task<ChiliUser> FindByIdAsync(this DbSet<ChiliUser> users, Guid id)
        {
            return await users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public static async Task<ChiliUser> FindByUsernameAsync(this DbSet<ChiliUser> users, string username)
        {
            return await users.FirstOrDefaultAsync(x => x.UserName == username);
        }
        public static async Task<ChiliUser> FindByEmailAsync(this DbSet<ChiliUser> users, string email)
        {
            return await users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}

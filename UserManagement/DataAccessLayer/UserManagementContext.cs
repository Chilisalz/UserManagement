using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagementService.Models;

namespace UserManagementService.DataAccessLayer
{
    public class UserManagementContext : IdentityDbContext<ChiliUser>
    {
        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options)
        {

        }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

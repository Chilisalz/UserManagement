using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagementService.DataAccessLayer;
using UserManagementService.Models;

namespace UserManagementService.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            string postgresConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<UserManagementContext>(options => options.UseNpgsql(postgresConnectionString));
            services.AddIdentity<ChiliUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
            }).AddEntityFrameworkStores<UserManagementContext>()
            .AddRoles<IdentityRole>();
        }
    }
}

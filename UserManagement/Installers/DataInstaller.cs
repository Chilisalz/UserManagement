using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagementService.DataAccessLayer;

namespace UserManagementService.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
#if DEBUG
            var connectionString = configuration.GetConnectionString("DefaultLocalConnectionString");
#elif RELEASE
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING", EnvironmentVariableTarget.Process);
#endif

            services.AddDbContext<UserManagementContext>(options => options.UseNpgsql(connectionString));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
#if RELEASE
using System;
#endif
using UserManagementService.DataAccessLayer;

namespace UserManagementService.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
#if DEBUG
            bool isUrl = Uri.TryCreate(configuration.GetConnectionString("DefaultLocalConnectionString"), UriKind.Absolute, out Uri url);

#elif RELEASE
            bool isUrl = Uri.TryCreate(Environment.GetEnvironmentVariable("DATABASE_URL", EnvironmentVariableTarget.Process), UriKind.Absolute, out Uri url);            
#endif
            if (isUrl)
            {
                var builder = new NpgsqlConnectionStringBuilder()
                {
                    Host = url.Host,
                    Port = url.Port,
                    Database = url.LocalPath[1..],
                    Username = url.UserInfo.Split(':')[0],
                    Password = url.UserInfo.Split(':')[1],
                    Pooling = true
                };
#if DEBUG
                builder.IntegratedSecurity = true;
#elif RELEASE
                builder.SslMode = SslMode.Require;
                builder.TrustServerCertificate = true;
#endif
                services.AddDbContext<UserManagementContext>(options => options.UseNpgsql(builder.ConnectionString));
            }

        }
    }
}

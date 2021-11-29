using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Threading.Tasks;
using UserManagementService.DataAccessLayer;
using UserManagementService.Installers;

namespace UserManagementService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build().MigrateDatabase<UserManagementContext>();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Listen(IPAddress.Any, Convert.ToInt32(Environment.GetEnvironmentVariable("PORT")));
                    }).UseStartup<Startup>();
                });
    }
}

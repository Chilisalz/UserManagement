using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using UserManagementService;
using UserManagementService.DataAccessLayer;
using UserManagementService.Models;

namespace UserManagement.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                //Remove prod service
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<UserManagementContext>));
            if (descriptor != null)
                services.Remove(descriptor);

                // Add a database context (AppDbContext) using an in-memory database for testing.                
                services.AddDbContext<UserManagementContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryAppDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var appDb = scopedServices.GetRequiredService<UserManagementContext>();

                var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();
                // Ensure the database is created.
                appDb.Database.EnsureDeleted();
                appDb.Database.EnsureCreated();
            });
        }
    }
}

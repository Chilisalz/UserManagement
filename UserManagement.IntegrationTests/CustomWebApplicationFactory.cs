using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
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

                // Add a database context (AppDbContext) using an in-memory database for testing.
                services.AddDbContext<UserManagementContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryAppDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var appDb = scopedServices.GetRequiredService<UserManagementContext>();

                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();
                    // Ensure the database is created.
                    appDb.Database.EnsureDeleted();
                    appDb.Database.EnsureCreated();
                    
                    try
                    {
                        var UserForGet = new ChiliUser()
                        {
                            Id = "7f6a9142-a177-466f-8c45-3c9281cfe5db",
                            Email = "getuser@chiliboard.de",
                            NormalizedEmail = "getuser@chiliboard.de".ToUpper(),
                            EmailConfirmed = false,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "51f5dbf9-b09e-4ebf-9c5d-0edd1e35c919",
                            LockoutEnabled = true,
                            LockoutEnd = null,
                            NormalizedUserName = "GetUser".ToUpper(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            RegistrationDate = DateTime.Now,
                            SecurityStamp = "PBBLISBKCX2SC2HZZZBU4WAECY4OOEAQ",
                            TwoFactorEnabled = false,
                            UserName = "GetUser"
                        };

                        var deleteUser = new ChiliUser()
                        {
                            Id = "6cef0153-5b95-4e88-9746-b67f9dccef31",
                            Email = "deleteUser@web.de",
                            NormalizedEmail = "deleteUser@web.de".ToUpper(),
                            EmailConfirmed = false,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d4a06fd5-06fb-4fb5-8669-80247ced5cdf",
                            LockoutEnabled = true,
                            LockoutEnd = null,
                            NormalizedUserName = "DeleteUser".ToUpper(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            RegistrationDate = DateTime.Now,
                            SecurityStamp = "LTH2MYEEUUL6EYVUKLWIA5RUWWJZ7USV",
                            TwoFactorEnabled = false,
                            UserName = "DeleteUser"
                        };

                        var passwordHasher = new PasswordHasher<ChiliUser>();
                        UserForGet.PasswordHash = passwordHasher.HashPassword(UserForGet, "get");
                        deleteUser.PasswordHash = passwordHasher.HashPassword(deleteUser, "delete");

                        appDb.Users.Add(UserForGet);
                        appDb.Users.Add(deleteUser);

                        appDb.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " + "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}

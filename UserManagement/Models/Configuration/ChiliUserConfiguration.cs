using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Models.Configuration
{
    internal class ChiliUserConfiguration : IEntityTypeConfiguration<ChiliUser>
    {
        public void Configure(EntityTypeBuilder<ChiliUser> builder)
        {
            PasswordHasher<ChiliUser> passwordHasher = new PasswordHasher<ChiliUser>();

            var adminUser = new ChiliUser
            {
                Id = Guid.Parse("0da09c36-50ac-44fb-a102-8b528bcbad51"),
                Email = "adminuser@chiliboard.de",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("39bf46f0-cc42-438f-866c-c20c393a307b"),
                UserName = "admin"
            };

            var casualUser = new ChiliUser()
            {
                Id = Guid.Parse("bf9657c5-0827-44bb-b902-f627d24c0313"),
                Email = "casualUser@web.de",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "CasualUser69420"
            };
            var catLover = new ChiliUser()
            {
                Id = Guid.Parse("8c8dd0dd-a6b6-478d-a298-1011cb5bf060"),
                Email = "catlover@gmail.com",
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                RegistrationDate = DateTime.Now,
                UserName = "CatLover123"
            };
            var adminPassword = passwordHasher.HashPassword(adminUser, "admin");
            var casualUserPassword = passwordHasher.HashPassword(casualUser, "casual");
            var catLoverPassword = passwordHasher.HashPassword(catLover, "cats");

            adminUser.PasswordHash = adminPassword;
            casualUser.PasswordHash = casualUserPassword;
            catLover.PasswordHash = catLoverPassword;

            builder.HasData(adminUser, casualUser, catLover);
        }
    }
}

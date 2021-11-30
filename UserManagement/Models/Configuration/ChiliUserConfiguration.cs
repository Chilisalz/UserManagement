using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace UserManagementService.Models.Configuration
{
    internal class ChiliUserConfiguration : IEntityTypeConfiguration<ChiliUser>
    {
        public void Configure(EntityTypeBuilder<ChiliUser> builder)
        {
            PasswordHasher<ChiliUser> passwordHasher = new();

            var adminUser = new ChiliUser
            {
                Id = Guid.Parse("0da09c36-50ac-44fb-a102-8b528bcbad51"),
                Email = "adminuser@chiliboard.de",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("39bf46f0-cc42-438f-866c-c20c393a307b"),
                UserName = "admin",
                SecretQuestionId = Guid.Parse("f7f78ebd-22d5-4861-893e-7dceee4ee4fe")
            };

            var casualUser = new ChiliUser()
            {
                Id = Guid.Parse("bf9657c5-0827-44bb-b902-f627d24c0313"),
                Email = "casualUser@web.de",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "CasualUser69420",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var catLover = new ChiliUser()
            {
                Id = Guid.Parse("8c8dd0dd-a6b6-478d-a298-1011cb5bf060"),
                Email = "catlover@gmail.com",
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                RegistrationDate = DateTime.Now,
                UserName = "CatLover123",
                SecretQuestionId = Guid.Parse("f3124fb0-79ce-403b-8cd4-eceafaf2a0ff")
            };
            var adminPassword = passwordHasher.HashPassword(adminUser, "admin");
            var casualUserPassword = passwordHasher.HashPassword(casualUser, "casual");
            var catLoverPassword = passwordHasher.HashPassword(catLover, "cats");

            var adminAnswer = passwordHasher.HashPassword(adminUser, "1789");
            var casualUserAnswer = passwordHasher.HashPassword(casualUser, "Schmitz");
            var catLoverAnswer = passwordHasher.HashPassword(catLover, "Katzen");

            adminUser.PasswordHash = adminPassword;
            casualUser.PasswordHash = casualUserPassword;
            catLover.PasswordHash = catLoverPassword;

            adminUser.SecretAnswer = adminAnswer;
            casualUser.SecretAnswer = casualUserAnswer;
            catLover.SecretAnswer = catLoverAnswer;

            builder.HasData(adminUser, casualUser, catLover);
        }
    }
}

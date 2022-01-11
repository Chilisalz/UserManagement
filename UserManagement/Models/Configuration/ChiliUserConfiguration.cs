
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

            var admin2 = new ChiliUser
            {
                Id = Guid.Parse("0da09c36-50ac-44fb-a102-8b528bcbad58"),
                Email = "nis@chiliboard.de",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("39bf46f0-cc42-438f-866c-c20c393a307b"),
                UserName = "nis",
                SecretQuestionId = Guid.Parse("f3124fb0-79ce-403b-8cd4-eceafaf2a0ff")
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

            #region TestUser
            var testUser1 = new ChiliUser
            {
                Id = Guid.Parse("25ca7448-72d4-11ec-90d6-0242ac120003"),
                Email = "rcwil@att.net",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "rcwil",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser2 = new ChiliUser
            {
                Id = Guid.Parse("25ca7696-72d4-11ec-90d6-0242ac120003"),
                Email = "pajas@sbcglobal.net",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "pajas",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser3 = new ChiliUser
            {
                Id = Guid.Parse("25ca77e0-72d4-11ec-90d6-0242ac120003"),
                Email = "kempsonc@comcast.net",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "kempsonc",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser4 = new ChiliUser
            {
                Id = Guid.Parse("25ca7920-72d4-11ec-90d6-0242ac120003"),
                Email = "rnelson@sbcglobal.net",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "rnelson",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser5 = new ChiliUser
            {
                Id = Guid.Parse("25ca7a4c-72d4-11ec-90d6-0242ac120003"),
                Email = "kempsonc@yahoo.ca",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "kempsonc",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser6 = new ChiliUser
            {
                Id = Guid.Parse("25ca7d44-72d4-11ec-90d6-0242ac120003"),
                Email = "sharon@yahoo.com",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "sharon",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser7 = new ChiliUser
            {
                Id = Guid.Parse("25ca7e8e-72d4-11ec-90d6-0242ac120003"),
                Email = "moonlapse@comcast.net",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "moonlapse",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser8 = new ChiliUser
            {
                Id = Guid.Parse("25ca7fa6-72d4-11ec-90d6-0242ac120003"),
                Email = "kspiteri@comcast.net",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "kspiteri",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser9 = new ChiliUser
            {
                Id = Guid.Parse("25ca80d2-72d4-11ec-90d6-0242ac120003"),
                Email = "dinther@sbcglobal.net",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "dinther",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser10 = new ChiliUser
            {
                Id = Guid.Parse("25ca81f4-72d4-11ec-90d6-0242ac120003"),
                Email = "janneh@mac.com",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "janneh",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser11 = new ChiliUser
            {
                Id = Guid.Parse("25ca8320-72d4-11ec-90d6-0242ac120003"),
                Email = "dwheeler@icloud.com",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "dwheeler",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser12 = new ChiliUser
            {
                Id = Guid.Parse("25ca8442-72d4-11ec-90d6-0242ac120003"),
                Email = "violinhi@me.com",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "violinhi",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser13 = new ChiliUser
            {
                Id = Guid.Parse("25ca856e-72d4-11ec-90d6-0242ac120003"),
                Email = "kewley@aol.com",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "kewley",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser14 = new ChiliUser
            {
                Id = Guid.Parse("25ca896a-72d4-11ec-90d6-0242ac120003"),
                Email = "mfleming@mac.com",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "mfleming",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser15 = new ChiliUser
            {
                Id = Guid.Parse("25ca8aa0-72d4-11ec-90d6-0242ac120003"),
                Email = "kosact@hotmail.com",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "kosact",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser16 = new ChiliUser
            {
                Id = Guid.Parse("25ca8bcc-72d4-11ec-90d6-0242ac120003"),
                Email = "fudrucker@sbcglobal.net",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "fudrucker",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser17 = new ChiliUser
            {
                Id = Guid.Parse("25ca8cf8-72d4-11ec-90d6-0242ac120003"),
                Email = "frosal@optonline.net",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "frosal",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser18 = new ChiliUser
            {
                Id = Guid.Parse("25ca8e24-72d4-11ec-90d6-0242ac120003"),
                Email = "gmcgath@gmail.com",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "gmcgath",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser19 = new ChiliUser
            {
                Id = Guid.Parse("25ca8f32-72d4-11ec-90d6-0242ac120003"),
                Email = "chaffar@mac.com",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "chaffar",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };
            var testUser20 = new ChiliUser
            {
                Id = Guid.Parse("25ca9040-72d4-11ec-90d6-0242ac120003"),
                Email = "ilial@icloud.com",
                RegistrationDate = DateTime.Now,
                ChiliUserRoleId = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                UserName = "ilial",
                SecretQuestionId = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215")
            };

            var testPasswort1 = passwordHasher.HashPassword(testUser1, "test");
            var testPasswort2 = passwordHasher.HashPassword(testUser2, "test");
            var testPasswort3 = passwordHasher.HashPassword(testUser3, "test");
            var testPasswort4 = passwordHasher.HashPassword(testUser4, "test");
            var testPasswort5 = passwordHasher.HashPassword(testUser5, "test");
            var testPasswort6 = passwordHasher.HashPassword(testUser6, "test");
            var testPasswort7 = passwordHasher.HashPassword(testUser7, "test");
            var testPasswort8 = passwordHasher.HashPassword(testUser8, "test");
            var testPasswort9 = passwordHasher.HashPassword(testUser9, "test");
            var testPasswort10 = passwordHasher.HashPassword(testUser10, "test");
            var testPasswort11 = passwordHasher.HashPassword(testUser11, "test");
            var testPasswort12 = passwordHasher.HashPassword(testUser12, "test");
            var testPasswort13 = passwordHasher.HashPassword(testUser13, "test");
            var testPasswort14 = passwordHasher.HashPassword(testUser14, "test");
            var testPasswort15 = passwordHasher.HashPassword(testUser15, "test");
            var testPasswort16 = passwordHasher.HashPassword(testUser16, "test");
            var testPasswort17 = passwordHasher.HashPassword(testUser17, "test");
            var testPasswort18 = passwordHasher.HashPassword(testUser18, "test");
            var testPasswort19 = passwordHasher.HashPassword(testUser19, "test");
            var testPasswort20 = passwordHasher.HashPassword(testUser20, "test");

            var testAnswer1 = passwordHasher.HashPassword(testUser1, "test");
            var testAnswer2 = passwordHasher.HashPassword(testUser2, "test");
            var testAnswer3 = passwordHasher.HashPassword(testUser3, "test");
            var testAnswer4 = passwordHasher.HashPassword(testUser4, "test");
            var testAnswer5 = passwordHasher.HashPassword(testUser5, "test");
            var testAnswer6 = passwordHasher.HashPassword(testUser6, "test");
            var testAnswer7 = passwordHasher.HashPassword(testUser7, "test");
            var testAnswer8 = passwordHasher.HashPassword(testUser8, "test");
            var testAnswer9 = passwordHasher.HashPassword(testUser9, "test");
            var testAnswer10 = passwordHasher.HashPassword(testUser10, "test");
            var testAnswer11 = passwordHasher.HashPassword(testUser11, "test");
            var testAnswer12 = passwordHasher.HashPassword(testUser12, "test");
            var testAnswer13 = passwordHasher.HashPassword(testUser13, "test");
            var testAnswer14 = passwordHasher.HashPassword(testUser14, "test");
            var testAnswer15 = passwordHasher.HashPassword(testUser15, "test");
            var testAnswer16 = passwordHasher.HashPassword(testUser16, "test");
            var testAnswer17 = passwordHasher.HashPassword(testUser17, "test");
            var testAnswer18 = passwordHasher.HashPassword(testUser18, "test");
            var testAnswer19 = passwordHasher.HashPassword(testUser19, "test");
            var testAnswer20 = passwordHasher.HashPassword(testUser20, "test");


            testUser1.SecretAnswer = testAnswer1;
            testUser2.SecretAnswer = testAnswer2;
            testUser3.SecretAnswer = testAnswer3;
            testUser4.SecretAnswer = testAnswer4;
            testUser5.SecretAnswer = testAnswer5;
            testUser6.SecretAnswer = testAnswer6;
            testUser7.SecretAnswer = testAnswer7;
            testUser8.SecretAnswer = testAnswer8;
            testUser9.SecretAnswer = testAnswer9;
            testUser10.SecretAnswer = testAnswer10;
            testUser11.SecretAnswer = testAnswer11;
            testUser12.SecretAnswer = testAnswer12;
            testUser13.SecretAnswer = testAnswer13;
            testUser14.SecretAnswer = testAnswer14;
            testUser15.SecretAnswer = testAnswer15;
            testUser16.SecretAnswer = testAnswer16;
            testUser17.SecretAnswer = testAnswer17;
            testUser18.SecretAnswer = testAnswer18;
            testUser19.SecretAnswer = testAnswer19;
            testUser20.SecretAnswer = testAnswer20;


            testUser1.PasswordHash = testPasswort1;
            testUser2.PasswordHash = testPasswort2;
            testUser3.PasswordHash = testPasswort3;
            testUser4.PasswordHash = testPasswort4;
            testUser5.PasswordHash = testPasswort5;
            testUser6.PasswordHash = testPasswort6;
            testUser7.PasswordHash = testPasswort7;
            testUser8.PasswordHash = testPasswort8;
            testUser9.PasswordHash = testPasswort9;
            testUser10.PasswordHash = testPasswort10;
            testUser11.PasswordHash = testPasswort11;
            testUser12.PasswordHash = testPasswort12;
            testUser13.PasswordHash = testPasswort13;
            testUser14.PasswordHash = testPasswort14;
            testUser15.PasswordHash = testPasswort15;
            testUser16.PasswordHash = testPasswort16;
            testUser17.PasswordHash = testPasswort17;
            testUser18.PasswordHash = testPasswort18;
            testUser19.PasswordHash = testPasswort19;
            testUser20.PasswordHash = testPasswort20;

            #endregion
            var adminPassword = passwordHasher.HashPassword(adminUser, "admin");
            var admin2Password = passwordHasher.HashPassword(adminUser, "dackel");
            var casualUserPassword = passwordHasher.HashPassword(casualUser, "casual");
            var catLoverPassword = passwordHasher.HashPassword(catLover, "cats");

            var adminAnswer = passwordHasher.HashPassword(adminUser, "1789");
            var admin2Answer = passwordHasher.HashPassword(adminUser, "dackel");
            var casualUserAnswer = passwordHasher.HashPassword(casualUser, "Schmitz");
            var catLoverAnswer = passwordHasher.HashPassword(catLover, "Katzen");



            adminUser.PasswordHash = adminPassword;
            admin2.PasswordHash = admin2Password;
            casualUser.PasswordHash = casualUserPassword;
            catLover.PasswordHash = catLoverPassword;

            adminUser.SecretAnswer = adminAnswer;
            admin2.SecretAnswer = admin2Answer;
            casualUser.SecretAnswer = casualUserAnswer;
            catLover.SecretAnswer = catLoverAnswer;

            builder.HasData(adminUser, casualUser, catLover, admin2, testUser1, testUser2, testUser3, testUser4, testUser5, testUser6, testUser7, testUser8, testUser9, testUser10, testUser11, testUser12, testUser13, testUser14, testUser15, testUser16, testUser17, testUser18, testUser19, testUser20);
        }
    }
}

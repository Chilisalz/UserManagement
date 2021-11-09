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

            var chiliAdmin = new ChiliUser()
            {
                Id = "0da09c36-50ac-44fb-a102-8b528bcbad51",
                Email = "adminuser@chiliboard.de",
                NormalizedEmail = "adminuser@chiliboard.de".ToUpper(),
                EmailConfirmed = false,
                AccessFailedCount = 0,
                ConcurrencyStamp = "51f5dbf9-b09e-4ebf-9c5d-0edd1e35c919",
                LockoutEnabled = true,
                LockoutEnd = null,
                NormalizedUserName = "ChiliSuperAdmin".ToUpper(),
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                RegistrationDate = DateTime.Now,
                SecurityStamp = "PBBLISBKCX2SC2HZZZBU4WAECY4OOEAQ",
                TwoFactorEnabled = false,
                UserName = "ChiliSuperAdmin"
            };

            var casualUser1 = new ChiliUser()
            {
                Id = "bf9657c5-0827-44bb-b902-f627d24c0313",
                Email = "casualUser@web.de",
                NormalizedEmail = "casualUser@web.de".ToUpper(),
                EmailConfirmed = false,
                AccessFailedCount = 0,
                ConcurrencyStamp = "d4a06fd5-06fb-4fb5-8669-80247ced5cdf",
                LockoutEnabled = true,
                LockoutEnd = null,
                NormalizedUserName = "CasualUser69420".ToUpper(),
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                RegistrationDate = DateTime.Now,
                SecurityStamp = "LTH2MYEEUUL6EYVUKLWIA5RUWWJZ7USV",
                TwoFactorEnabled = false,
                UserName = "CasualUser69420"
            };

            var casualUser2 = new ChiliUser()
            {
                Id = "8c8dd0dd-a6b6-478d-a298-1011cb5bf060",
                Email = "catlover@gmail.com",
                NormalizedEmail = "catlover@gmail.com".ToUpper(),
                EmailConfirmed = false,
                AccessFailedCount = 0,
                ConcurrencyStamp = "37dc169f-8a94-4962-bec4-1b826f69238c",
                LockoutEnabled = true,
                LockoutEnd = null,
                NormalizedUserName = "CatLover123".ToUpper(),
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                RegistrationDate = DateTime.Now,
                SecurityStamp = "WZ2YPIJWNNJEIXICV3UT5ITRWDK2QPRZ",
                TwoFactorEnabled = false,
                UserName = "CatLover123"
            };

            var passwordHasher = new PasswordHasher<ChiliUser>();
            chiliAdmin.PasswordHash = passwordHasher.HashPassword(chiliAdmin, "admin");
            casualUser1.PasswordHash = passwordHasher.HashPassword(casualUser1, "casual");
            casualUser2.PasswordHash = passwordHasher.HashPassword(casualUser2, "cats");
            
            builder.HasData(
                chiliAdmin,
                casualUser1,
                casualUser2
                );
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Models.Configuration
{
    internal class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "39bf46f0-cc42-438f-866c-c20c393a307b",
                    ConcurrencyStamp = "6030eb4c-db57-46ba-8e99-266e2f862379",
                    Name = "Admin",
                    NormalizedName = ("Admin").ToUpper()
                },
                new IdentityRole()
                {
                    Id = "372a7671-ab69-4450-b77f-306aeb4eb8f1",
                    ConcurrencyStamp = "c18e2fd3-2f19-466c-bd7d-3723f882f721",
                    Name = "DefaultChiliUser",
                    NormalizedName = "DefaultChiliUser".ToUpper()
                });
        }
    }
}

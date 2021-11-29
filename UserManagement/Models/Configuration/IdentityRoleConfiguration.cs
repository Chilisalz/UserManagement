using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace UserManagementService.Models.Configuration
{
    internal class ChiliRoleConfiguration : IEntityTypeConfiguration<ChiliUserRole>
    {
        public void Configure(EntityTypeBuilder<ChiliUserRole> builder)
        {
            builder.HasData(
                new ChiliUserRole
                {
                    Id = Guid.Parse("39bf46f0-cc42-438f-866c-c20c393a307b"),
                    Rolename = "Admin"
                },
                new ChiliUserRole()
                {
                    Id = Guid.Parse("372a7671-ab69-4450-b77f-306aeb4eb8f1"),
                    Rolename = "DefaultChiliUser"
                });
        }
    }
}

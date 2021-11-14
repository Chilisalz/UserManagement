using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManagementService.Models.Configuration
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = "39bf46f0-cc42-438f-866c-c20c393a307b",
                    UserId = "0da09c36-50ac-44fb-a102-8b528bcbad51"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "372a7671-ab69-4450-b77f-306aeb4eb8f1",
                    UserId = "bf9657c5-0827-44bb-b902-f627d24c0313"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "372a7671-ab69-4450-b77f-306aeb4eb8f1",
                    UserId = "8c8dd0dd-a6b6-478d-a298-1011cb5bf060"
                });


        }
    }
}

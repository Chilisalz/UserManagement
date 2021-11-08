using Microsoft.AspNetCore.Identity;
using System;

namespace UserManagementService.Models
{
    public class ChiliUser : IdentityUser
    {
        public DateTime RegistrationDate { get; set; }
        public MemberRole Role { get; set; }
    }
}

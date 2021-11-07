using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Authentication;

namespace UserManagementService.Models
{
    public class ChiliUser : IdentityUser
    {
        public DateTime RegistrationDate { get; set; }
        public MemberRole Role { get; set; }
    }
}

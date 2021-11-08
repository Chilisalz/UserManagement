using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementService.Models
{
    public class ChiliUser : IdentityUser
    {     
        public DateTime RegistrationDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Contracts.Requests
{
    public class UserRegistrationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}

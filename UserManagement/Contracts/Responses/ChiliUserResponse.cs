using System;
using UserManagementService.Models;

namespace UserManagementService.Contracts.Responses
{
    public class ChiliUserResponse
    {
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public Guid Id { get; set; }
    }
}

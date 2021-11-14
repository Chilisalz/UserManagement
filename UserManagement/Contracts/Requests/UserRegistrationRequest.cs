using System.ComponentModel.DataAnnotations;

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

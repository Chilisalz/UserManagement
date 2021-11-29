using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Contracts.Requests
{
    public class ChiliUserRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Username { get; set; }
    }
}

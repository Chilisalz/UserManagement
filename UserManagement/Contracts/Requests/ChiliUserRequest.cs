using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Contracts.Requests
{
    public class ChiliUserRequest
    {
        public Guid Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}

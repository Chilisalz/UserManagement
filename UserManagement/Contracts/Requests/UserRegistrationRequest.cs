using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Contracts.Requests
{
    public class UserRegistrationRequest
    {
        [Required(ErrorMessage = "Username cannot be empty.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "New Password cannot be empty.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{12,}$", ErrorMessage = "Password must be at least 12 characters in length, contain at least one digit, one uppercase letter, one lowercase letter and one special character.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email cannot be empty.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Secretquestion cannot be empty.")]
        public Guid SecretQuestion { get; set; }
        [Required(ErrorMessage = "SecretAnswer cannot be empty.")]
        public string SecretAnswer { get; set; }
    }
}

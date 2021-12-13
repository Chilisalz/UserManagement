using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Dtos
{
    public class UserRegistrationDto
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

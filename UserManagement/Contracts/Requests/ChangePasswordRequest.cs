using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Contracts.Requests
{
    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "New Password cannot be empty.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{12,}$", ErrorMessage = "Password must be at least 12 characters in length, contain at least one digit, one uppercase letter, one lowercase letter and one special character.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}

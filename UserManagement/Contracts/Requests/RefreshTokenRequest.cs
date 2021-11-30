using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Contracts.Requests
{
    public class RefreshTokenRequest
    {
        [Required(ErrorMessage = "Accesstoken cannot be empty.")]
        public string Token { get; set; }
        [Required(ErrorMessage = "Refreshtoken cannot be empty.")]
        public string RefreshToken { get; set; }
    }
}

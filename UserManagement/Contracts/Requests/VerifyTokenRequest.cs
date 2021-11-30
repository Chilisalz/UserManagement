using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Contracts.Requests
{
    public class VerifyTokenRequest
    {
        [Required(ErrorMessage = "Accesstoken cannot be empty.")]
        public string Token { get; set; }
    }
}

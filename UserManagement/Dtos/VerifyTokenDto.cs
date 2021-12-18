using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Dtos
{
    public class VerifyTokenDto
    {
        [Required(ErrorMessage = "Accesstoken cannot be empty.")]
        public string Token { get; set; }
    }
}

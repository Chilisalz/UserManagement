using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Dtos
{
    public class ValidateSecretAnswerDto
    {
        [Required(ErrorMessage = "UserId cannot be empty.")]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Secretanswer cannot be empty.")]
        public string SecretAnswer { get; set; }
    }
}

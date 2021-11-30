using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Contracts.Requests
{
    public class ValidateSecretAnswerRequest
    {
        [Required(ErrorMessage = "UserId cannot be empty.")]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Secretanswer cannot be empty.")]
        public string SecretAnswer { get; set; }
    }
}

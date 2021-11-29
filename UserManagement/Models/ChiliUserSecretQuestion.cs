using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Models
{
    public class ChiliUserSecretQuestion
    {
        [Key]
        public Guid QuestionId { get; set; }
        public string SecretQuestion { get; set; }
    }
}

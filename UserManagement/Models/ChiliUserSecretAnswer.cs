using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Models
{
    public class ChiliUserSecretAnswer
    {
        [Key]
        public Guid AnswerId { get; set; }
        public string SecretAnswer { get; set; }
        public Guid QuestionId { get; set; }
        [ForeignKey(nameof(QuestionId))]
        public ChiliUserSecretQuestion SecretQuestion { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ChiliUser User { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Models
{
    public class SecurityQuestion
    {
        [Key]
        public Guid Id { get; set; }
        public string Question { get; set; }
    }
}

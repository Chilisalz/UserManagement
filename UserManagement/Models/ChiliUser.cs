using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementService.Models
{
    public class ChiliUser
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Guid ChiliUserRoleId { get; set; }
        [ForeignKey(nameof(ChiliUserRoleId))]
        public virtual ChiliUserRole Role { get; set; }
    }
}

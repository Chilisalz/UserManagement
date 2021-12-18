using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Dtos.ChiliUser
{
    public class ChiliUserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Guid ChiliUserRoleId { get; set; }
        public Guid SecretQuestionId { get; set; }
    }
}

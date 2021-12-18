using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Models;

namespace UserManagementService.Dtos
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

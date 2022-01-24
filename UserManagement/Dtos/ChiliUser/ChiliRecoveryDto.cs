using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Dtos.ChiliUser
{
    public class ChiliRecoveryDto
    {
        public Guid Id { get; set; }
        public Guid SecretQuestionId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Dtos;
using UserManagementService.Models;

namespace UserManagementService.Services.ServiceResult
{
    public class GetUsersResultDto
    {
        public List<ChiliUserAdminViewDto> Users { get; set; }
        public Pagination Pagination { get; set; }
    }
}

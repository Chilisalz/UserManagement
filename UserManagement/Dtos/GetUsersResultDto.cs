using System.Collections.Generic;
using UserManagementService.Dtos.ChiliUser;

namespace UserManagementService.Dtos
{
    public class GetUsersResultDto
    {
        public List<ChiliUserAdminViewDto> Users { get; set; }
        public Pagination Pagination { get; set; }
    }
}

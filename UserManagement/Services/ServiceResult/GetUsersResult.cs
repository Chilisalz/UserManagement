using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Models;

namespace UserManagementService.Services.ServiceResult
{
    public class GetUsersResult
    {
        public List<ChiliUser> Users { get; set; }
        public Pagination Pagination { get; set; }
    }
}

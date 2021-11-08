using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public interface IChiliUserService
    {
        Task<ChiliUser> GetChiliUserById(Guid id);
        Task<List<ChiliUser>> GetAllUsersAsync();
    }
}

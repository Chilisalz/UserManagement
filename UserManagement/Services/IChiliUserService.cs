using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public interface IChiliUserService
    {
        Task<ChiliUser> GetChiliUserById(Guid id);
        Task<List<ChiliUser>> GetAllUsersAsync();
        Task<IdentityResult> DeleteUser(Guid id);
        Task<ChiliUserUpdateResult> UpdateUserAsync(Guid id, ChiliUserRequest request);
    }
}

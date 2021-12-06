using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Models;
using UserManagementService.Models.ServiceResults;

namespace UserManagementService.Services
{
    public interface IUserService
    {
        Task<ChiliUser> GetChiliUserByIdAsync(Guid id);
        Task<List<ChiliUser>> GetAllUsersAsync();
        Task<DeleteResult> DeleteUserAsync(Guid id);
        Task<ChiliUserUpdateResult> UpdateUserAsync(Guid id, ChiliUserRequest request);
        Task<ChangePasswordResult> ChangePasswordAsync(Guid id, ChangePasswordRequest request);
    }
}

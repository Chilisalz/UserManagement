using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Dtos;
using UserManagementService.Models;
using UserManagementService.Models.ServiceResults;

namespace UserManagementService.Services
{
    public interface IUserService
    {
        Task<ChiliUser> GetChiliUserByIdAsync(Guid id);
        Task<List<ChiliUser>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(Guid id);
        Task<ChiliUserDto> UpdateUserAsync(Guid id, ChiliUserDto request);
        Task<bool> ChangePasswordAsync(Guid id, ChangePasswordRequest request);
    }
}

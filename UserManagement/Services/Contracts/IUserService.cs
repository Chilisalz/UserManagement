using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Dtos;
using UserManagementService.Models;
using UserManagementService.Services.ServiceResult;

namespace UserManagementService.Services
{
    public interface IUserService
    {
        Task<ChiliUserDto> GetChiliUserByIdAsync(Guid id);
        Task<GetUsersResultDto> GetAllUsersAsync(int page);
        Task<bool> DeleteUserAsync(Guid id);
        Task<ChiliUserDto> UpdateUserAsync(Guid id, ChiliUserDto request);
        Task<bool> ChangePasswordAsync(Guid id, ChangePasswordRequest request);
        Task<List<SecurityQuestion>> GetAllSecurityQuestionsAsync();
        Task<bool> ValidateSecretAnswerAsync(ValidateSecretAnswerRequest request);
        Task<SecurityQuestion> GetSecurityQuestionOfUserAsync(string email);
    }
}

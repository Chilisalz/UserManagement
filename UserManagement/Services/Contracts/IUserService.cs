using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Dtos;
using UserManagementService.Dtos.ChiliUser;
using UserManagementService.Models;

namespace UserManagementService.Services.Contracts
{
    public interface IUserService
    {
        Task<ChiliUserDto> GetChiliUserByIdAsync(Guid id);
        Task<GetUsersResultDto> GetAllUsersAsync(int page);
        Task DeleteUserAsync(Guid id);
        Task<ChiliUserDto> UpdateUserAsync(Guid id, ChiliUserDto request);
        Task ChangePasswordAsync(Guid id, ChangePasswordDto request);
        Task<List<SecurityQuestion>> GetAllSecurityQuestionsAsync();
        Task ValidateSecretAnswerAsync(ValidateSecretAnswerDto request);
        Task<SecurityQuestion> GetSecurityQuestionOfUserAsync(string email);
        List<ChiliUserNameDto> MapChiliUser(List<Guid> request);
        Task<ChiliRecoveryDto> GetRecoveryInformation(string email);
    }
}

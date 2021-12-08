using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Dtos;
using UserManagementService.Models;
using UserManagementService.Models.ServiceResults;

namespace UserManagementService.Services
{
    public interface IAuthenticationService
    {
        Task<ChiliUserDto> RegisterAsync(UserRegistrationRequest request);
        Task<AuthenticationResult> LoginAsync(string userName, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
        bool VerifyToken(string token);
        Task<List<SecurityQuestion>> GetAllSecurityQuestionsAsync();
        Task<bool> ValidateSecretAnswerAsync(ValidateSecretAnswerRequest request);
        Task<SecurityQuestion> GetSecurityQuestionOfUserAsync(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(UserRegistrationRequest request);
        Task<AuthenticationResult> LoginAsync(string userName, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
        VerificationResult VerifyToken(string token);
        Task<List<SecurityQuestion>> GetAllSecurityQuestionsAsync();
        Task<VerificationResult> ValidateSecretAnswerAsync(ValidateSecretAnswerRequest request);
        Task<SecurityQuestion> GetSecurityQuestionOfUserAsync(Guid id);
    }
}

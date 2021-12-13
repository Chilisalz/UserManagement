using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Dtos;

namespace UserManagementService.Services
{
    public interface IAuthenticationService
    {
        Task<ChiliUserDto> RegisterAsync(UserRegistrationDto request);
        Task<AuthenticationDto> LoginAsync(string userName, string password);
        Task<AuthenticationDto> RefreshTokenAsync(string token, string refreshToken);
        bool VerifyToken(string token);        
    }
}

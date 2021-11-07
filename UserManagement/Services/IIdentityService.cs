using System.Threading.Tasks;
using UserManagementService.Authentication;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public interface IIdentityService
    {
        public Task<AuthenticationResult> RegisterAsync(string email, string password, string userName);
        public Task<AuthenticationResult> LoginAsync(string userName, string password);
        public Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}

using System.Threading.Tasks;
using UserManagementService.Authentication;

namespace UserManagementService.Services
{
    public interface IIdentityService
    {
        public Task<AuthenticationResult> RegisterAsync(string email, string password, string userName);
        public Task<AuthenticationResult> LoginAsync(string userName, string password);
    }
}

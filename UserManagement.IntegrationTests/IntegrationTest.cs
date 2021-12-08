using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;
using UserManagementService.Contracts.Requests;
using UserManagementService.Contracts.Responses;
using Xunit;

namespace UserManagement.IntegrationTests
{
    [Collection("Sequentiell")]
    public class IntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient TestClient;
        protected readonly (string, string, string) _existingUsercredentials = ("admin", "adminuser@chiliboard.de", "admin");
        public IntegrationTest(CustomWebApplicationFactory<Startup> factory)
        {
            TestClient = factory.CreateClient();
        }
        protected async Task<string> GetJwtAsync()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserLoginRequest()
                {
                    UserName = _existingUsercredentials.Item2,
                    Password = _existingUsercredentials.Item3
                }), Encoding.UTF8, "application/json");
            var response = await TestClient.PostAsync("/api/Authentication/Login", request);

            //return JsonConvert.DeserializeObject<AuthSuccessResponse>(await response.Content.ReadAsStringAsync());
            return null;
        }
    }
}

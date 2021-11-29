using System.Net.Http;
using UserManagementService;
using Xunit;

namespace UserManagement.IntegrationTests
{
    [Collection("Sequentiell")]
    public class IntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient TestClient;
        public IntegrationTest(CustomWebApplicationFactory<Startup> factory)
        {
            TestClient = factory.CreateClient();
        }
    }
}

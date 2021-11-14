using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;
using UserManagementService;
using UserManagementService.DataAccessLayer;
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

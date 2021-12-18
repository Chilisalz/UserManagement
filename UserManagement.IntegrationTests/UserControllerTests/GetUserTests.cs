using FluentAssertions;
using System;
using System.Net;
using System.Threading.Tasks;
using UserManagementService;
using Xunit;

namespace UserManagement.IntegrationTests.UserControllerTests
{
    public class GetUserTests : UserControllerTests
    {
        public GetUserTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task GetUserById_WithNonExistingId_ReturnsNotFound()
        {
            // Arrange
            var invalidGuid = Guid.Empty;
            // Act
            var response = await TestClient.GetAsync($"/api/ChiliUser/{invalidGuid}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task GetUserById_WithExistingId_ReturnsOk()
        {
            // Arrange
            var validGuid = "bf9657c5-0827-44bb-b902-f627d24c0313";
            // Act
            var response = await TestClient.GetAsync($"/api/ChiliUser/User/{validGuid}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}

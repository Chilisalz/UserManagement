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
            var validGuid = "0da09c36-50ac-44fb-a102-8b528bcbad51";
            // Act
            var response = await TestClient.GetAsync($"/api/ChiliUser/User/{validGuid}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}

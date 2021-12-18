using FluentAssertions;
using System;
using System.Net;
using System.Threading.Tasks;
using UserManagementService;
using Xunit;

namespace UserManagement.IntegrationTests.UserControllerTests
{
    public class DeleteUserTests : UserControllerTests
    {
        public DeleteUserTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task DeleteUser_WithNonExistingId_ReturnsError()
        {
            // Arrange
            var invalidGuid = Guid.Empty;
            // Act
            var response = await TestClient.DeleteAsync($"/api/ChiliUser/{invalidGuid}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task DeleteUser_WithExistingId_ReturnsSuccess()
        {
            // Arrange
            var validId = "8c8dd0dd-a6b6-478d-a298-1011cb5bf060";
            // Act
            var response = await TestClient.DeleteAsync($"/api/ChiliUser/User/{validId}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}

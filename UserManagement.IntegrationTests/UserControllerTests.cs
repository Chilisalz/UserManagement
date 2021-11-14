using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using UserManagementService;

namespace UserManagement.IntegrationTests
{
    public class UserControllerTests : IntegrationTest
    {
        public UserControllerTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
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
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
        [Fact]
        public async Task DeleteUser_WithExistingId_ReturnsSuccess()
        {
            // Arrange
            var validId = "6cef0153-5b95-4e88-9746-b67f9dccef31";
            // Act
            var response = await TestClient.DeleteAsync($"/api/ChiliUser/{validId}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
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
            var invalidGuid = "bf9657c5-0827-44bb-b902-f627d24c0313";
            // Act
            var response = await TestClient.GetAsync($"/api/ChiliUser/{invalidGuid}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}

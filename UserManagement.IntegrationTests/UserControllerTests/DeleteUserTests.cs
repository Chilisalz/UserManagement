using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;
using Xunit;

namespace UserManagement.IntegrationTests.UserControllerTests
{
    public class DeleteUserTests :IntegrationTest
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
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
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

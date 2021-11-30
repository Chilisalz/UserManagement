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
            var validId = "6cef0153-5b95-4e88-9746-b67f9dccef31";
            // Act
            var response = await TestClient.DeleteAsync($"/api/ChiliUser/{validId}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}

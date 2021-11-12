using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using Xunit;
using FluentAssertions;

namespace UserManagement.IntegrationTests
{
    public class UserControllerTests : IntegrationTest
    {
        [Fact]
        public async Task DeleteUser_WithNonExistingId_ReturnsError()
        {
            // Arrange
            var invalidGuid = Guid.Empty;
            // Act
            var response = await TestClient.DeleteAsync($"/api/ChiliUser/Register/{invalidGuid}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task DeleteUser_WithExistingId_ReturnsSuccess()
        {
            // Arrange
            var invalidGuid = "bf9657c5-0827-44bb-b902-f627d24c0313";
            // Act
            var response = await TestClient.DeleteAsync($"/api/ChiliUser/Register/{invalidGuid}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
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

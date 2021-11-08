using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using Xunit;

namespace UserManagement.IntegrationTests
{
    public class AuthenticationControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Register_WithAlreadyUsedEmail_ReturnsError()
        {
            // Arrange
            var request = new StringContent(JsonConvert.SerializeObject(new UserRegistrationRequest() { Email = "user@example.com", UserName = "Tester", Password = "Test123456!" }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
    }
}

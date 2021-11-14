using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;
using UserManagementService.Contracts.Requests;
using Xunit;

namespace UserManagement.IntegrationTests
{
    public class AuthenticationControllerTests : IntegrationTest
    {
        public AuthenticationControllerTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }
        [Fact]
        public async Task Register_WithAlreadyUsedEmail_ReturnsError()
        {
            // Arrange
            var emailUsed = "getuser@chiliboard.de";
            var username = "Test";
            var password = "Test123456!";
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationRequest()
                {
                    Email = emailUsed,
                    UserName = username,
                    Password = password
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Register_WithAlreadyUsedUsername_ReturnsError()
        {
            // Arrange
            var emailUsed = "getuserNew@chiliboard.de";
            var username = "GetUser";
            var password = "Test123456!";
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationRequest()
                {
                    Email = emailUsed,
                    UserName = username,
                    Password = password
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Register_NewUser_ReturnsOk()
        {
            // Arrange
            var emailUsed = "getuserNew@chiliboard.de";
            var username = "GetUserNew";
            var password = "Test123456!";
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationRequest()
                {
                    Email = emailUsed,
                    UserName = username,
                    Password = password
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Register_EmailInvalid_ReturnsBadRequest()
        {
            // Arrange
            var emailUsed = "getuserNew#chiliboard.de";
            var username = "GetUserNew";
            var password = "Test123456!";
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationRequest()
                {
                    Email = emailUsed,
                    UserName = username,
                    Password = password
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Register_PasswordInvalid_ReturnsBadRequest()
        {
            // Arrange
            var emailUsed = "getuserNew@chiliboard.de";
            var username = "GetUserNew";
            var password = "Tes!";
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationRequest()
                {
                    Email = emailUsed,
                    UserName = username,
                    Password = password
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Register_EmptyUserName_ReturnsBadRequest()
        {
            // Arrange
            var emailUsed = "getuserNew@chiliboard.de";
            var username = "";
            var password = "Test123456!";
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationRequest()
                {
                    Email = emailUsed,
                    UserName = username,
                    Password = password
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}

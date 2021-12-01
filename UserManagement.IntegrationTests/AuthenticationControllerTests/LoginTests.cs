using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;
using UserManagementService.Contracts.Requests;
using Xunit;
using FluentAssertions;

namespace UserManagement.IntegrationTests.AuthenticationControllerTests
{
    public class LoginTests : IntegrationTest
    {        
        private readonly (string, string, string) _nonExistingUsercredentials = ("notadmin", "notadminuser@chiliboard.de", "asdf");

        public LoginTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
            
        }
        #region OK
        [Fact]
        public async Task Login_WithUsernameValid_ReturnsOK()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserLoginRequest()
                {
                    UserName = _existingUsercredentials.Item1,
                    Password = _existingUsercredentials.Item3
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Login", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Login_WithEmailValid_ReturnsOK()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserLoginRequest()
                {
                    UserName = _existingUsercredentials.Item2,
                    Password = _existingUsercredentials.Item3
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Login", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        #endregion
        #region ERROR
        [Fact]
        public async Task Login_WithInvalidUsername_ReturnsBadRequest()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserLoginRequest()
                {
                    UserName = _nonExistingUsercredentials.Item1,
                    Password = _existingUsercredentials.Item3
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Login", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Login_WithInvalidPassword_ReturnsBadRequest()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserLoginRequest()
                {
                    UserName = _existingUsercredentials.Item1,
                    Password = _nonExistingUsercredentials.Item3
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Login", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Login_WithEmptyCredentials_ReturnsBadRequest()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserLoginRequest()
                {
                    UserName = string.Empty,
                    Password = string.Empty
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Login", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        #endregion
    }
}

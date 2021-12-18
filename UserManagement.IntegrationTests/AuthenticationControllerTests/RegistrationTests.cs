using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;
using UserManagementService.Dtos;
using Xunit;

namespace UserManagement.IntegrationTests
{
    public class RegistrationTests : IntegrationTest
    {
        private readonly string _alreadyUsedUsername = "CasualUser69420";
        private readonly string _alreadyUsedEmail = "casualUser@web.de";
        private readonly string _invalidPassword = "Test123";
        private readonly string _invalidEmail = "test#4711.de";
        private Guid _invalidSecretQuestion = Guid.NewGuid();
        private readonly string _validEmail = "testemail@domain.de";
        private readonly string _validUsername = "NewTestUser";
        private readonly string _validPassword = "De49py72xc0wzg!?";
        private readonly string _validSecretAnswer = "Das ist eine valide Antwort!";
        private Guid _validSecretQuestion = Guid.Parse("f3124fb0-79ce-403b-8cd4-eceafaf2a0ff");
        public RegistrationTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }
        #region OK
        [Fact]
        public async Task Register_NewUser_ReturnsOk()
        {
            // Arrange            
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationDto()
                {
                    Email = _validEmail,
                    UserName = _validUsername,
                    Password = _validPassword,
                    SecretQuestion = _validSecretQuestion,
                    SecretAnswer = _validSecretAnswer
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        #endregion
        #region ERROR
        [Fact]
        public async Task Register_WithAlreadyUsedEmail_ReturnsError()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationDto()
                {
                    Email = _alreadyUsedEmail,
                    UserName = _validUsername,
                    Password = _validPassword,
                    SecretQuestion = _validSecretQuestion,
                    SecretAnswer = _validSecretAnswer
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }
        [Fact]
        public async Task Register_WithAlreadyUsedUsername_ReturnsError()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationDto()
                {
                    Email = _validEmail,
                    UserName = _alreadyUsedUsername,
                    Password = _validPassword,
                    SecretQuestion = _validSecretQuestion,
                    SecretAnswer = _validSecretAnswer
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }
        [Fact]
        public async Task Register_EmailInvalid_ReturnsBadRequest()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationDto()
                {
                    Email = _invalidEmail,
                    UserName = _validUsername,
                    Password = _validPassword,
                    SecretAnswer = _validSecretAnswer,
                    SecretQuestion = _validSecretQuestion
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Register_PasswordInvalid_ReturnsBadRequest()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationDto()
                {
                    Email = _validEmail,
                    UserName = _validUsername,
                    Password = _invalidPassword,
                    SecretQuestion = _validSecretQuestion,
                    SecretAnswer = _validSecretAnswer
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Register_EmptyUserName_ReturnsBadRequest()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationDto()
                {
                    Email = _validEmail,
                    UserName = string.Empty,
                    Password = _validPassword,
                    SecretAnswer = _validSecretAnswer,
                    SecretQuestion = _validSecretQuestion
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Register_InvalidSecretQuestion_ReturnsBadRequest()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new UserRegistrationDto()
                {
                    Email = _validEmail,
                    UserName = _validUsername,
                    Password = _validPassword,
                    SecretAnswer = _validSecretAnswer,
                    SecretQuestion = _invalidSecretQuestion
                }), Encoding.UTF8, "application/json");
            // Act
            var response = await TestClient.PostAsync("/api/Authentication/Register", request);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        #endregion        
    }
}

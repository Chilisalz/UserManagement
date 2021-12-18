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

namespace UserManagement.IntegrationTests.AuthenticationControllerTests
{
    public class TokenTests : IntegrationTest
    {
        private readonly string _expiredAccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbiIsImp0aSI6IjY3OTExN2VhLTZhMTAtNDUyOC04M2E5LTM4ZmMzNmFjOTU2NSIsImVtYWlsIjoiYWRtaW51c2VyQGNoaWxpYm9hcmQuZGUiLCJpZCI6IjBkYTA5YzM2LTUwYWMtNDRmYi1hMTAyLThiNTI4YmNiYWQ1MSIsIm5iZiI6MTYzODMwMjYzNSwiZXhwIjoxNjM4MzAzNTM1LCJpYXQiOjE2MzgzMDI2MzV9.J4FlrdKAUnkqCF6nCv4D-CpXVOsUpJkrYTY2iYxj3YY";
        public TokenTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }
        #region OK    
        #endregion
        #region ERROR
        [Fact]
        public async Task RefreshToken_ExpiredAccessAndInvalidRefresh_BadRequest()
        {
            var request = new StringContent(JsonConvert.SerializeObject(
                new AuthenticationDto()
                {
                    Token = _expiredAccessToken,
                    RefreshToken = Guid.NewGuid().ToString()
                }), Encoding.UTF8, "application/json");

            var response = await TestClient.PostAsync("/api/Authentication/RefreshToken", request);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        #endregion
    }
}

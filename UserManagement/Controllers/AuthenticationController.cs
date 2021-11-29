using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Contracts.Responses;
using UserManagementService.Services;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public AuthenticationController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new FailedResponseBase()
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }
            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password, request.UserName);
            if (!authResponse.Success)
            {
                return BadRequest(new FailedResponseBase()
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken
            });

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var authResponse = await _identityService.LoginAsync(request.UserName, request.Password);
            if (!authResponse.Success)
            {
                return BadRequest(new FailedResponseBase()
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken
            });
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var authResponse = await _identityService.RefreshTokenAsync(request.Token, request.RefreshToken);
            if (!authResponse.Success)
            {
                return BadRequest(new FailedResponseBase()
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken
            });
        }
        [HttpPost("VerifyToken")]
        public IActionResult VerifyToken([FromBody] VerifyTokenRequest request)
        {
            var verifyResponse = _identityService.VerifyToken(request.Token);
            if (verifyResponse.Verified)
            {
                return Ok(new VerificationSuccessResponse()
                {
                    Token = request.Token
                });
            }
            else
            {
                return BadRequest(new FailedResponseBase()
                {
                    Errors = verifyResponse.Errors
                });
            }
        }
    }
}
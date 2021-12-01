using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IAuthenticationService _identityService;
        public AuthenticationController(IAuthenticationService identityService)
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
            var authResponse = await _identityService.RegisterAsync(request);
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
        [HttpGet("Secretquestion")]
        public async Task<IActionResult> GetAllSecrurityQuestionsAsync()
        {
            var questions = await _identityService.GetAllSecurityQuestionsAsync();
            return Ok(questions);
        }
        [HttpPost("ValidateSecretAnswer")]
        public async Task<IActionResult> ValidateSecretAnswerAsync([FromBody] ValidateSecretAnswerRequest request)
        {
            var verificationResult = await _identityService.ValidateSecretAnswerAsync(request);
            if (!verificationResult.Verified)
                return BadRequest(new FailedResponseBase()
                {
                    Errors = verificationResult.Errors
                });
            return Ok();
        }
        [HttpGet("Secretquestion/{userId}")]
        public async Task<IActionResult> GetSecurityQuestionOfUserAsync([FromRoute] Guid userId)
        {
            var question = await _identityService.GetSecurityQuestionOfUserAsync(userId);
            return Ok(question);
        }
    }
}
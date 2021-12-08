using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Contracts.Responses;
using UserManagementService.Dtos;
using UserManagementService.Exceptions;
using UserManagementService.Models.ServiceResults;
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
                return BadRequest(new BaseResponse<UserRegistrationRequest>()
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)),
                    Content = request,
                });
            }
            try
            {
                var authResponse = await _identityService.RegisterAsync(request);
                return Ok(new BaseResponse<ChiliUserDto>()
                {
                    Content = authResponse,
                });
            }
            catch (Exception ex)
            {
                if (ex is EmailAlreadyTakenException || ex is UsernameAlreadyTakenException)
                    return Conflict(new BaseResponse<UserRegistrationRequest>()
                    {
                        Content = request,
                        Errors = new[] { ex.Message }
                    });
                else if (ex is SecretQuestionNotFoundException)
                    return NotFound(new BaseResponse<UserRegistrationRequest>()
                    {
                        Content = request,
                        Errors = new[] { ex.Message }
                    });
                else
                    throw;
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            try
            {
                var authResponse = await _identityService.LoginAsync(request.UserName, request.Password);

                return Ok(new BaseResponse<AuthenticationResult>
                {
                    Content = authResponse
                });
            }
            catch (Exception ex)
            {
                if (ex is UserNotFoundException)
                    return NotFound(new BaseResponse<UserLoginRequest>()
                    {
                        Content = request,
                        Errors = new[] { ex.Message }
                    });
                else if (ex is InvalidPasswordException)
                    return Conflict(new BaseResponse<UserLoginRequest>()
                    {
                        Content = request,
                        Errors = new[] { ex.Message }
                    });
                else
                    throw;
            }
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var authResponse = await _identityService.RefreshTokenAsync(request.Token, request.RefreshToken);
                return Ok(new BaseResponse<AuthenticationResult>
                {
                    Content = authResponse
                });
            }

            catch (Exception ex)
            {
                return BadRequest(new BaseResponse<RefreshTokenRequest>()
                {
                    Errors = new[] { ex.Message },
                    Content = request
                });
            }
        }
        [HttpPost("VerifyToken")]
        public IActionResult VerifyToken([FromBody] VerifyTokenRequest request)
        {
            try
            {
                var verifyResponse = _identityService.VerifyToken(request.Token);
                return Ok(new BaseResponse<string>()
                {
                    Content = request.Token,
                });
            }
            catch (InvalidTokenException ex)
            {
                return BadRequest(new BaseResponse<string>()
                {
                    Errors = new[] { ex.Message },
                    Content = request.Token
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
            try
            {
                var verificationResult = await _identityService.ValidateSecretAnswerAsync(request);
                return Ok(new BaseResponse<Guid>()
                {
                    Content = request.UserId
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new BaseResponse<Guid>()
                {
                    Errors = new[] { ex.Message },
                    Content = request.UserId
                });
            }
            catch (WrongSecretAnswerException ex)
            {
                return BadRequest(new BaseResponse<Guid>()
                {
                    Errors = new[] { ex.Message },
                    Content = request.UserId
                });
            }                       
        }
        [HttpGet("Secretquestion/{userId}")]
        public async Task<IActionResult> GetSecurityQuestionOfUserAsync([FromRoute] Guid userId)
        {
            var question = await _identityService.GetSecurityQuestionOfUserAsync(userId);
            return Ok(question);
        }
    }
}
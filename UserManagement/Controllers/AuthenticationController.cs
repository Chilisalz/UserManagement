using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Contracts.Responses;
using UserManagementService.Dtos;
using UserManagementService.Exceptions;
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
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ChiliResponse<UserRegistrationDto>()
                {
                    Status = ResponseStatus.error,
                    Error = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToString()
                });
            }
            try
            {
                var authResponse = await _identityService.RegisterAsync(request);
                return Ok(new ChiliResponse<ChiliUserDto>()
                {
                    Status = ResponseStatus.success,
                    Data = authResponse,
                });
            }
            catch (Exception ex)
            {
                if (ex is WebApiException)
                    return StatusCode(Convert.ToInt32((ex as WebApiException).StatusCode), new ChiliResponse<object>()
                    {
                        Status = ResponseStatus.error,
                        Error = ex.Message
                    });
                else
                    return StatusCode(500, new ChiliListResponse<object>()
                    {
                        Status = ResponseStatus.error,
                        Error = ex.Message
                    });
            }
        }        
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto request)
        {
            try
            {
                var authResponse = await _identityService.LoginAsync(request.UserName, request.Password);

                return Ok(new ChiliResponse<AuthenticationDto>
                {
                    Status = ResponseStatus.success,
                    Data = authResponse
                });
            }
            catch (Exception ex)
            {
                if (ex is UserNotFoundException)
                    return NotFound(new ChiliResponse<UserLoginDto>()
                    {
                        Status = ResponseStatus.error,
                        Error = ex.Message
                    });
                else if (ex is InvalidPasswordException)
                    return Conflict(new ChiliResponse<UserLoginDto>()
                    {
                        Status = ResponseStatus.error,
                        Error = ex.Message
                    });
                else
                    throw;
            }
        }
        [HttpPost("Token/Refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] AuthenticationDto request)
        {
            try
            {
                var authResponse = await _identityService.RefreshTokenAsync(request.Token, request.RefreshToken);
                return Ok(new ChiliResponse<AuthenticationDto>
                {
                    Status = ResponseStatus.success,
                    Data = authResponse
                });
            }

            catch (Exception ex)
            {
                return BadRequest(new ChiliResponse<AuthenticationDto>()
                {
                    Status = ResponseStatus.error,
                    Error = ex.Message,
                });
            }
        }
        [HttpPost("Token/Verify")]
        public IActionResult VerifyToken([FromBody] VerifyTokenRequest request)
        {
            try
            {
                var verifyResponse = _identityService.VerifyToken(request.Token);
                return Ok(new ChiliResponse<string>()
                {
                    Status = ResponseStatus.success,
                    Data = request.Token,
                });
            }
            catch (InvalidTokenException ex)
            {
                return BadRequest(new ChiliResponse<string>()
                {
                    Status = ResponseStatus.error,
                    Error = ex.Message
                });
            }
        }
    }
}
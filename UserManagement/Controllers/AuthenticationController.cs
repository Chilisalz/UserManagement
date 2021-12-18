using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [EnableCors("CorsPolicy")]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto request)
        {
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
                        Errors = new[] { ex.Message }
                    });
                else
                    return StatusCode(500, new ChiliListResponse<object>()
                    {
                        Status = ResponseStatus.error,
                        Errors = new [] { ex.Message }
                    });
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto request)
        {
            try
            {
                var authResponse = await _identityService.LoginAsync(request);

                return Ok(new ChiliResponse<AuthenticationDto>
                {
                    Status = ResponseStatus.success,
                    Data = authResponse
                });
            }
            catch (Exception ex)
            {
                if (ex is WebApiException)
                    return StatusCode(Convert.ToInt32((ex as WebApiException).StatusCode), new ChiliResponse<object>()
                    {
                        Status = ResponseStatus.error,
                        Errors = new[] { ex.Message }
                    });
                else
                    return StatusCode(500, new ChiliListResponse<object>()
                    {
                        Status = ResponseStatus.error,
                        Errors = new[] { ex.Message }
                    });
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
                    Errors = new[] { ex.Message }
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
                    Errors = new[] { ex.Message }
                });
            }
        }
    }
}
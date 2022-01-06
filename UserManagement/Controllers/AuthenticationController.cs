using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using UserManagementService.Dtos;
using UserManagementService.Dtos.ChiliUser;
using UserManagementService.Responses;
using UserManagementService.Services.Contracts;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _identityService;
        private readonly ILogger _logger;
        /// <summary>
        /// Registriert einen neuen Benutzer im Chiliuserboard.
        /// </summary>
        /// <param name="identityService"></param>
        /// <param name="logger"></param>
        public AuthenticationController(IAuthenticationService identityService, ILogger<AuthenticationController> logger)
        {
            _identityService = identityService;
            _logger = logger;
        }
        [EnableCors("CorsPolicy")]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto request)
        {
            _logger.LogInformation("Entering /api/Authentication/Register");
            return Ok(new ChiliResponse<ChiliUserDto>()
            {
                Status = ResponseStatus.success,
                Data = await _identityService.RegisterAsync(request),
            });
        }
        [EnableCors("CorsPolicy")]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto request)
        {
            _logger.LogInformation("Entering /api/Authentication/Login");
            return Ok(new ChiliResponse<AuthenticationDto>
            {
                Status = ResponseStatus.success,
                Data = await _identityService.LoginAsync(request)
            });
        }
        [HttpPost("Token/Verify")]
        public async Task<IActionResult> VerifyToken([FromBody] AuthenticationDto request)
        {
            _logger.LogInformation("Entering /api/Authentication/Token/Verify");
            return Ok(new ChiliResponse<AuthenticationDto>
            {
                Status = ResponseStatus.success,
                Data = await _identityService.VerifyTokenAsync(request.Token, request.RefreshToken)
            });
        }
    }
}
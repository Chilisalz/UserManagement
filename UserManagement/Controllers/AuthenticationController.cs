using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        public AuthenticationController(IAuthenticationService identityService)
        {
            _identityService = identityService;
        }
        [EnableCors("CorsPolicy")]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto request)
        {
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
            return Ok(new ChiliResponse<AuthenticationDto>
            {
                Status = ResponseStatus.success,
                Data = await _identityService.LoginAsync(request)
            });
        }
        [HttpPost("Token/Verify")]
        public async Task<IActionResult> VerifyToken([FromBody] AuthenticationDto request)
        {
            return Ok(new ChiliResponse<AuthenticationDto>
            {
                Status = ResponseStatus.success,
                Data = await _identityService.VerifyTokenAsync(request.Token, request.RefreshToken)
            });
        }
    }
}
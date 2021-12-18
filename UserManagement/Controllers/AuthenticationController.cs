﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManagementService.Contracts.Responses;
using UserManagementService.Dtos;
using UserManagementService.Dtos.ChiliUser;
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
        [HttpPost("Token/Refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] AuthenticationDto request)
        {
            return Ok(new ChiliResponse<AuthenticationDto>
            {
                Status = ResponseStatus.success,
                Data = await _identityService.RefreshTokenAsync(request.Token, request.RefreshToken)
            });
        }
        [HttpPost("Token/Verify")]
        public IActionResult VerifyToken([FromBody] VerifyTokenDto request)
        {
            _identityService.VerifyToken(request.Token);
            return Ok(new ChiliResponse<object>()
            {
                Status = ResponseStatus.success
            });
        }
    }
}
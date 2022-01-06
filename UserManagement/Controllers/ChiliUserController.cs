using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Dtos;
using UserManagementService.Dtos.ChiliUser;
using UserManagementService.Models;
using UserManagementService.Responses;
using UserManagementService.Services.Contracts;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiliUserController : ControllerBase
    {
        private readonly IUserService _chiliUserService;
        private readonly ILogger _logger;
        public ChiliUserController(IUserService chiliUserService, ILogger<ChiliUserController> logger)
        {
            _chiliUserService = chiliUserService;
            _logger = logger;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute] Guid userId)
        {
            _logger.LogInformation($"Entering api/ChiliUser/{userId}");
            return Ok(new ChiliResponse<ChiliUserDto>()
            {
                Data = await _chiliUserService.GetChiliUserByIdAsync(userId),
                Status = ResponseStatus.success
            });
        }
        [HttpGet("{page}/users")]
        public async Task<IActionResult> GetAll([FromRoute] int page)
        {
            _logger.LogInformation($"Entering api/ChiliUser/{page}/users");
            var users = await _chiliUserService.GetAllUsersAsync(page);
            return Ok(new ChiliListResponse<List<ChiliUserAdminViewDto>>()
            {
                Status = ResponseStatus.success,
                Pagination = users.Pagination,
                Data = users.Users
            });
        }
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid userId, [FromBody] ChiliUserDto request)
        {
            return Ok(new ChiliResponse<ChiliUserDto>()
            {
                Status = ResponseStatus.success,
                Data = await _chiliUserService.UpdateUserAsync(userId, request),
            });
        }
        [HttpPut("{userId}/ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromRoute] Guid userId, [FromBody] ChangePasswordDto passwordRequest)
        {
            _logger.LogInformation($"Entering api/ChiliUser/{userId}/ChangePassword");
            await _chiliUserService.ChangePasswordAsync(userId, passwordRequest);
            return Ok(new ChiliResponse<object>()
            {
                Status = ResponseStatus.success
            });
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid userId)
        {
            _logger.LogInformation($"Entering api/ChiliUser/{userId}");
            await _chiliUserService.DeleteUserAsync(userId);
            return Ok(new ChiliResponse<object>()
            {
                Status = ResponseStatus.success
            });
        }
        [HttpGet("Secretquestion")]
        public async Task<IActionResult> GetAllSecrurityQuestionsAsync()
        {
            _logger.LogInformation($"Entering api/ChiliUser/Secretquestion");
            return Ok(new ChiliResponse<List<SecurityQuestion>>()
            {
                Status = ResponseStatus.success,
                Data = await _chiliUserService.GetAllSecurityQuestionsAsync()
            });
        }
        [HttpPost("ValidateSecretAnswer")]
        public async Task<IActionResult> ValidateSecretAnswerAsync([FromBody] ValidateSecretAnswerDto request)
        {
            _logger.LogInformation($"Entering api/ChiliUser/ValidateSecretAnswer");
            await _chiliUserService.ValidateSecretAnswerAsync(request);
            return Ok(new ChiliResponse<object>()
            {
                Status = ResponseStatus.success
            });
        }
        [HttpPost("MapUsers")]
        public IActionResult MapChiliUsers([FromBody] List<Guid> request)
        {
            _logger.LogInformation($"Entering api/ChiliUser/MapUsers");
            var users = _chiliUserService.MapChiliUser(request);
            return Ok(new ChiliResponse<List<ChiliUserNameDto>>()
            {
                Status = ResponseStatus.success,
                Data = users
            });
        }
    }
}

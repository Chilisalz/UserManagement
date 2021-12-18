using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Contracts.Responses;
using UserManagementService.Dtos;
using UserManagementService.Exceptions;
using UserManagementService.Models;
using UserManagementService.Services;
using UserManagementService.Services.ServiceResult;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiliUserController : ControllerBase
    {
        private readonly IUserService _chiliUserService;
        public ChiliUserController(IUserService chiliUserService)
        {
            _chiliUserService = chiliUserService;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute] Guid userId)
        {
            try
            {
                var user = await _chiliUserService.GetChiliUserByIdAsync(userId);
                return Ok(new ChiliResponse<ChiliUserDto>()
                {
                    Data = user,
                    Status = ResponseStatus.success
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new ChiliResponse<object>()
                {
                    Status = ResponseStatus.error,
                    Errors = new[] { ex.Message }
                });
            }
        }
        [HttpGet("{page}/users")]
        public async Task<IActionResult> GetAll([FromRoute] int page)
        {
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
            if (!ModelState.IsValid)
            {
                return BadRequest(new ChiliResponse<ChiliUserDto>()
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)),
                    Status = ResponseStatus.fail
                });
            }
            try
            {
                var updateUserResult = await _chiliUserService.UpdateUserAsync(userId, request);

                return Ok(new ChiliResponse<ChiliUserDto>()
                {
                    Status = ResponseStatus.success,
                    Data = updateUserResult,
                });
            }
            catch (Exception ex)
            {
                if (ex is UserNotFoundException)
                    return NotFound(new ChiliResponse<ChiliUserDto>()
                    {
                        Status = ResponseStatus.error,
                        Errors = new[] { ex.Message }
                    });
                else if (ex is UsernameAlreadyTakenException || ex is EmailAlreadyTakenException)
                    return Conflict(new ChiliResponse<ChiliUserDto>()
                    {
                        Status = ResponseStatus.error,
                        Errors = new[] { ex.Message }
                    });
                else
                    throw;
            }
        }
        [HttpPut("{userId}/ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromRoute] Guid userId, [FromBody] ChangePasswordRequest passwordRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ChiliResponse<Guid>()
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)),
                    Status = ResponseStatus.error
                });
            try
            {
                var changePasswordResult = await _chiliUserService.ChangePasswordAsync(userId, passwordRequest);
                return Ok(new ChiliResponse<Guid>()
                {
                    Data = userId,
                    Status = ResponseStatus.success
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new ChiliResponse<Guid>()
                {
                    Status = ResponseStatus.error,
                    Errors = new[] { ex.Message }
                });
            }
            catch (InvalidPasswordException ex)
            {
                return Conflict(new ChiliResponse<Guid>()
                {
                    Status = ResponseStatus.error,
                    Errors = new[] { ex.Message }
                });
            }
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid userId)
        {
            try
            {
                var success = await _chiliUserService.DeleteUserAsync(userId);
                return Ok(new ChiliResponse<Guid>()
                {
                    Data = userId,
                    Status = ResponseStatus.success
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new ChiliResponse<Guid>()
                {
                    Status = ResponseStatus.error,
                    Errors = new[] { ex.Message }
                });
            }
        }
        [HttpGet("Secretquestion")]
        public async Task<IActionResult> GetAllSecrurityQuestionsAsync()
        {
            var questions = await _chiliUserService.GetAllSecurityQuestionsAsync();
            return Ok(new ChiliResponse<List<SecurityQuestion>>()
            {
                Status = ResponseStatus.success,
                Data = questions
            });
        }
        [HttpPost("ValidateSecretAnswer")]
        public async Task<IActionResult> ValidateSecretAnswerAsync([FromBody] ValidateSecretAnswerRequest request)
        {
            try
            {
                var verificationResult = await _chiliUserService.ValidateSecretAnswerAsync(request);
                return Ok(new ChiliResponse<Guid>()
                {
                    Data = request.UserId,
                    Status = ResponseStatus.success
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new ChiliResponse<Guid>()
                {
                    Errors = new[] { ex.Message },
                    Status = ResponseStatus.error
                });
            }
            catch (WrongSecretAnswerException ex)
            {
                return BadRequest(new ChiliResponse<Guid>()
                {
                    Errors = new[] { ex.Message },
                    Status = ResponseStatus.error
                });
            }
        }
        [HttpGet("{email}/Secretquestion")]
        public async Task<IActionResult> GetSecurityQuestionOfUserAsync([FromRoute] string email)
        {
            try
            {
                var question = await _chiliUserService.GetSecurityQuestionOfUserAsync(email);
                return Ok(new ChiliResponse<SecurityQuestion>()
                {
                    Status = ResponseStatus.success,
                    Data = question
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new ChiliResponse<SecurityQuestion>()
                {
                    Status = ResponseStatus.error,
                    Errors = new[] { ex.Message }
                });
            }
        }
    }
}

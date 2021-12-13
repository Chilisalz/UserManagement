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

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiliUserController : ControllerBase
    {
        private readonly IUserService _chiliUserService;
        private readonly IMapper _mapper;
        public ChiliUserController(IUserService chiliUserService, IMapper mapper)
        {
            _chiliUserService = chiliUserService;
            _mapper = mapper;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute] Guid userId)
        {
            try
            {
                var user = await _chiliUserService.GetChiliUserByIdAsync(userId);
                return Ok(new BaseResponse<ChiliUserDto>()
                {
                    Data = _mapper.Map<ChiliUserDto>(user)
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new BaseResponse<Guid>()
                {
                    Data = userId,
                    Error = ex.Message
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _chiliUserService.GetAllUsersAsync();
            return Ok(new BaseResponse<List<ChiliUserDto>>()
            {
                Data = _mapper.Map<List<ChiliUserDto>>(users)
            });
        }
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid userId, [FromBody] ChiliUserDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BaseResponse<ChiliUserDto>()
                {
                    Error = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToString(),
                    Data = request
                });
            }
            try
            {
                var updateUserResult = await _chiliUserService.UpdateUserAsync(userId, request);

                return Ok(new BaseResponse<ChiliUserDto>()
                {
                    Data = updateUserResult,
                });
            }
            catch (Exception ex)
            {
                if (ex is UserNotFoundException)
                    return NotFound(new BaseResponse<ChiliUserDto>()
                    {
                        Data = request,
                        Error = ex.Message
                    });
                else if (ex is UsernameAlreadyTakenException || ex is EmailAlreadyTakenException)
                    return Conflict(new BaseResponse<ChiliUserDto>()
                    {
                        Data = request,
                        Error = ex.Message
                    });
                else
                    throw;
            }
        }
        [HttpPut("{userId}/ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromRoute] Guid userId, [FromBody] ChangePasswordRequest passwordRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(new BaseResponse<Guid>()
                {
                    Error = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToString(),
                    Data = userId
                });
            try
            {
                var changePasswordResult = await _chiliUserService.ChangePasswordAsync(userId, passwordRequest);
                return Ok(new BaseResponse<Guid>()
                {
                    Data = userId
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new BaseResponse<Guid>()
                {
                    Data = userId,
                    Error = ex.Message
                });
            }
            catch (InvalidPasswordException ex)
            {
                return Conflict(new BaseResponse<Guid>()
                {
                    Data = userId,
                    Error = ex.Message
                });
            }
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid userId)
        {
            try
            {
                var success = await _chiliUserService.DeleteUserAsync(userId);
                return Ok(new BaseResponse<Guid>()
                {
                    Data = userId
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new BaseResponse<Guid>()
                {
                    Data = userId,
                    Error = ex.Message
                });
            }
        }
        [HttpGet("Secretquestion")]
        public async Task<IActionResult> GetAllSecrurityQuestionsAsync()
        {
            var questions = await _chiliUserService.GetAllSecurityQuestionsAsync();
            return Ok(new BaseResponse<List<SecurityQuestion>>()
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
                return Ok(new BaseResponse<Guid>()
                {
                    Data = request.UserId
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new BaseResponse<Guid>()
                {
                    Error = ex.Message,
                    Data = request.UserId
                });
            }
            catch (WrongSecretAnswerException ex)
            {
                return BadRequest(new BaseResponse<Guid>()
                {
                    Error = ex.Message,
                    Data = request.UserId
                });
            }
        }
        [HttpGet("{email}/Secretquestion")]
        public async Task<IActionResult> GetSecurityQuestionOfUserAsync([FromRoute] string email)
        {
            try
            {
                var question = await _chiliUserService.GetSecurityQuestionOfUserAsync(email);
                return Ok(new BaseResponse<SecurityQuestion>()
                {
                    Status = ResponseStatus.success,
                    Data = question
                });
            }
            catch (UserNotFoundException ex)
            {
                return Ok(new BaseResponse<SecurityQuestion>()
                {
                    Status = ResponseStatus.success,
                    Error = ex.Message
                });
            }
        }
    }
}

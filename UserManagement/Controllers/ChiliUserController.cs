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
        [HttpGet("User/{userId}")]
        public async Task<IActionResult> Get([FromRoute] Guid userId)
        {
            try
            {
                var user = await _chiliUserService.GetChiliUserByIdAsync(userId);
                return Ok(new BaseResponse<ChiliUserDto>()
                {
                    Content = _mapper.Map<ChiliUserDto>(user)
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new BaseResponse<Guid>()
                {
                    Content = userId,
                    Errors = new[] { ex.Message }
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _chiliUserService.GetAllUsersAsync();
            return Ok(new BaseResponse<List<ChiliUserDto>>()
            {
                Content = _mapper.Map<List<ChiliUserDto>>(users)
            });
        }
        [HttpPut("User/{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid userId, [FromBody] ChiliUserDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BaseResponse<ChiliUserDto>()
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)),
                    Content = request
                });
            }
            try
            {
                var updateUserResult = await _chiliUserService.UpdateUserAsync(userId, request);

                return Ok(new BaseResponse<ChiliUserDto>()
                {
                    Content = updateUserResult,
                });
            }
            catch (Exception ex)
            {
                if (ex is UserNotFoundException)
                    return NotFound(new BaseResponse<ChiliUserDto>()
                    {
                        Content = request,
                        Errors = new[] { ex.Message }
                    });
                else if (ex is UsernameAlreadyTakenException || ex is EmailAlreadyTakenException)
                    return Conflict(new BaseResponse<ChiliUserDto>()
                    {
                        Content = request,
                        Errors = new[] { ex.Message }
                    });
                else
                    throw;
            }
        }
        [HttpPut("User/ChangePassword/{userId}")]
        public async Task<IActionResult> ChangePassword([FromRoute] Guid userId, [FromBody] ChangePasswordRequest passwordRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(new BaseResponse<Guid>()
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)),
                    Content = userId
                });
            try
            {
                var changePasswordResult = await _chiliUserService.ChangePasswordAsync(userId, passwordRequest);
                return Ok(new BaseResponse<Guid>()
                {
                    Content = userId
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new BaseResponse<Guid>()
                {
                    Content = userId,
                    Errors = new[] { ex.Message }
                });
            }
            catch(InvalidPasswordException ex)
            {
                return Conflict(new BaseResponse<Guid>()
                {
                    Content = userId,
                    Errors = new[] { ex.Message }
                });
            }
        }
        [HttpDelete("User/{userId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid userId)
        {
            try
            {
                var success = await _chiliUserService.DeleteUserAsync(userId);
                return Ok(new BaseResponse<Guid>()
                {
                    Content = userId
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new BaseResponse<Guid>()
                {
                    Content = userId,
                    Errors = new[] { ex.Message }
                });
            }
        }
    }
}

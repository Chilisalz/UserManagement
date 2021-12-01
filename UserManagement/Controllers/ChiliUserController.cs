using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Contracts.Requests;
using UserManagementService.Contracts.Responses;
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
            var user = await _chiliUserService.GetChiliUserByIdAsync(userId);
            if (user == null)
                return NotFound();
            return Ok(_mapper.Map<ChiliUserResponse>(user));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _chiliUserService.GetAllUsersAsync();
            return Ok(_mapper.Map<List<ChiliUserResponse>>(users));
        }
        [HttpPut("User/{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid userId, [FromBody] ChiliUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new FailedResponseBase()
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }
            var updateUserResult = await _chiliUserService.UpdateUserAsync(userId, user);
            if (updateUserResult.Succeeded)
            {

                return Ok(new UpdateChiliUserSuccessResponse()
                {
                    User = _mapper.Map<ChiliUserResponse>(updateUserResult.User)
                });
            }
            else
            {
                return StatusCode((int)updateUserResult.HttpStatusCode, new FailedResponseBase()
                {
                    Errors = updateUserResult.Errors
                });
            }
        }
        [HttpPut("User/ChangePassword/{userId}")]
        public async Task<IActionResult> ChangePassword([FromRoute] Guid userId, [FromBody] ChangePasswordRequest passwordRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(new FailedResponseBase()
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            var changePasswordResult = await _chiliUserService.ChangePasswordAsync(userId, passwordRequest);
            if (changePasswordResult.Success)
                return Ok();
            else
                return StatusCode((int)changePasswordResult.HttpStatusCode, new FailedResponseBase()
                {
                    Errors = changePasswordResult.Errors
                });
        }
        [HttpDelete("User/{userId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid userId)
        {
            var deleteResult = await _chiliUserService.DeleteUserAsync(userId);
            if (deleteResult.Success)
            {
                return Ok(new DeleteSuccessResponse()
                {
                    UserId = userId
                });
            }
            else
            {
                return BadRequest(new FailedResponseBase()
                {
                    Errors = deleteResult.Errors
                });
            }
        }
    }
}

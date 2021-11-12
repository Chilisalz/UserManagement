using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Contracts.Responses;
using UserManagementService.Services;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class ChiliUserController : ControllerBase
    {
        private readonly IChiliUserService _chiliUserService;
        private readonly IMapper _mapper;
        public ChiliUserController(IChiliUserService chiliUserService, IMapper mapper)
        {
            _chiliUserService = chiliUserService;
            _mapper = mapper;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute] Guid userId)
        {
            var user = await _chiliUserService.GetChiliUserById(userId);
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
    }
}

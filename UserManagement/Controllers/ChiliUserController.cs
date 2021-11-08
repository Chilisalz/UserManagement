using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserManagementService.Services;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class ChiliUserController : ControllerBase
    {
        private readonly IChiliUserService _chiliUserService;
        public ChiliUserController(IChiliUserService chiliUserService)
        {
            _chiliUserService = chiliUserService;
        }
        [HttpGet("{userId}")]
        public IActionResult Get([FromRoute] Guid userId)
        {
            var user = _chiliUserService.GetChiliUserById(userId);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _chiliUserService.GetAllUsersAsync());
        }
    }
}

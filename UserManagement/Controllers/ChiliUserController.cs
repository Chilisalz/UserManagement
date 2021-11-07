using Microsoft.AspNetCore.Mvc;
using System;
using UserManagementService.Services;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}

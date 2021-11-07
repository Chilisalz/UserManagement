using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public class ChiliUserService : IChiliUserService
    {
        private readonly UserManager<ChiliUser> _userManager;
        public ChiliUserService(UserManager<ChiliUser> userManager)
        {
            _userManager = userManager;
        }
        public ChiliUser GetChiliUserById(Guid id)
        {
            return _userManager.Users.SingleOrDefault(x => x.Id == id.ToString());
        }
    }
}

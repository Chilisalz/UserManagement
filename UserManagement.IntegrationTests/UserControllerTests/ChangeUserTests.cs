using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;

namespace UserManagement.IntegrationTests.UserControllerTests
{
    public class ChangeUserTests : UserControllerTests
    {
        public ChangeUserTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }
    }
}

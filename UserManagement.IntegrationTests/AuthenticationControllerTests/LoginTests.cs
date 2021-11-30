using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;

namespace UserManagement.IntegrationTests.AuthenticationControllerTests
{
    public class LoginTests : IntegrationTest
    {
        public LoginTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }
    }
}

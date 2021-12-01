using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;
using UserManagementService.Contracts.Requests;
using UserManagementService.Contracts.Responses;

namespace UserManagement.IntegrationTests.UserControllerTests
{
    public class UserControllerTests : IntegrationTest
    {
        public UserControllerTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }        
    }
}

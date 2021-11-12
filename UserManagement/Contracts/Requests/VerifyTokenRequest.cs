using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Contracts.Requests
{
    public class VerifyTokenRequest
    {
        public string Token { get; set; }
    }
}

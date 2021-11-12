using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Contracts.Responses
{
    public class VerificationFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}

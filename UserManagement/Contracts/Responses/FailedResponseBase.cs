using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Contracts.Responses
{
    public abstract class FailedResponseBase
    {
        public IEnumerable<string> Errors { get; set; }
    }
}

using System.Collections.Generic;

namespace UserManagementService.Contracts.Responses
{
    public abstract class FailedResponseBase
    {
        public IEnumerable<string> Errors { get; set; }
    }
}

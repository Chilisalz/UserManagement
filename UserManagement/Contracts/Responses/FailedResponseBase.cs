using System.Collections.Generic;

namespace UserManagementService.Contracts.Responses
{
    public class FailedResponseBase
    {
        public IEnumerable<string> Errors { get; set; }
    }
}

using System.Collections.Generic;

namespace UserManagementService.Models
{
    public class VerificationResult
    {
        public bool Verified { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Models
{
    public class VerificationResult
    {
        public bool Verified { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}

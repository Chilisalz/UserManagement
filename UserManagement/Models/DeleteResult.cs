using System;
using System.Collections.Generic;

namespace UserManagementService.Models
{
    public class DeleteResult
    {
        public Guid UserId { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}

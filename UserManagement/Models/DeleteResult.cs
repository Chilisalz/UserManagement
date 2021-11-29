using System;
using System.Collections.Generic;
using System.Net;

namespace UserManagementService.Models
{
    public class DeleteResult
    {
        public Guid UserId { get; set; }
        public bool Success { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}

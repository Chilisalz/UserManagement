using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UserManagementService.Models
{
    public class ChangePasswordResult
    {
        public Guid UserId { get; set; }
        public bool Success { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}

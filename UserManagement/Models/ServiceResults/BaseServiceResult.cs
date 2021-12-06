using System.Collections.Generic;
using System.Net;

namespace UserManagementService.Models.ServiceResults
{
    public abstract class BaseServiceResult
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

    }
}

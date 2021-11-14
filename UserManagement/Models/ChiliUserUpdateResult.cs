using System.Collections.Generic;
using System.Net;

namespace UserManagementService.Models
{
    public class ChiliUserUpdateResult
    {
        public IEnumerable<string> Errors { get; set; }
        public bool Succeeded { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public ChiliUser User { get; set; }
        public ChiliUser ChiliUser { get; set; }
    }
}

using System.Collections.Generic;

namespace UserManagementService.Responses
{
    public class ChiliResponse<T>
    {
        public ResponseStatus Status { get; set; }
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}

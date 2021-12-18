using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UserManagementService.Contracts.Responses
{
    public class ChiliResponse<T>
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ResponseStatus Status { get; set; }
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }        
    }
}

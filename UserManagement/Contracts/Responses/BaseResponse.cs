using System.Text.Json.Serialization;

namespace UserManagementService.Contracts.Responses
{
    public class BaseResponse<T>
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ResponseStatus Status { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }        
    }
}

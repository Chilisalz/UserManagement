using System.Text.Json.Serialization;

namespace UserManagementService.Contracts.Responses
{
    public class ChiliResponse<T>
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ResponseStatus Status { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }        
    }
}

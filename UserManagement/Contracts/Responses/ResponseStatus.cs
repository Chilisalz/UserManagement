using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace UserManagementService.Contracts.Responses
{    
    public enum ResponseStatus
    {        
        success,
        fail,
        error
    }
}

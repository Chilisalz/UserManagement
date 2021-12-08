using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Contracts.Responses
{
    public class BaseResponse<T>
    {
        public T Content { get; set; }
        public IEnumerable<string> Errors { get; set; }        
    }
}

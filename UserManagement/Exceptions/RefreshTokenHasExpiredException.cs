using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class RefreshTokenHasExpiredException : WebApiException
    {
        public RefreshTokenHasExpiredException() : base(HttpStatusCode.Conflict)
        {

        }

        public RefreshTokenHasExpiredException(string message) : base(message, HttpStatusCode.Conflict)
        {

        }

        public RefreshTokenHasExpiredException(string message, Exception inner) : base(message, inner, HttpStatusCode.Conflict)
        {

        }
    }
}

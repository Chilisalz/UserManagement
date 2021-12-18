using System;
using System.Net;

namespace UserManagementService.Exceptions
{
    public class TokenHasntExpiredException : WebApiException
    {
        public TokenHasntExpiredException() : base(HttpStatusCode.Conflict)
        {

        }

        public TokenHasntExpiredException(string message) : base(message, HttpStatusCode.Conflict)
        {

        }

        public TokenHasntExpiredException(string message, Exception inner) : base(message, inner, HttpStatusCode.Conflict)
        {

        }
    }
}

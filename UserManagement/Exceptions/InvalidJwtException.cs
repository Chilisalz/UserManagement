using System;
using System.Net;

namespace UserManagementService.Exceptions
{
    public class InvalidJwtException : WebApiException
    {
        public InvalidJwtException() : base(HttpStatusCode.Conflict)
        {

        }

        public InvalidJwtException(string message) : base(message, HttpStatusCode.Conflict)
        {

        }

        public InvalidJwtException(string message, Exception inner) : base(message, inner, HttpStatusCode.Conflict)
        {

        }
    }
}

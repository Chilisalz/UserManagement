using System;
using System.Net;

namespace UserManagementService.Exceptions
{
    public class InvalidTokenException : WebApiException
    {
        public InvalidTokenException() : base(HttpStatusCode.Conflict)
        {

        }

        public InvalidTokenException(string message) : base(message, HttpStatusCode.Conflict)
        {

        }

        public InvalidTokenException(string message, Exception inner) : base(message, inner, HttpStatusCode.Conflict)
        {

        }
    }
}

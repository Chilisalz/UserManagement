using System;
using System.Net;

namespace UserManagementService.Exceptions
{
    public class InvalidPasswordException : WebApiException
    {
        public InvalidPasswordException() : base(HttpStatusCode.Conflict)
        {

        }

        public InvalidPasswordException(string message) : base(message, HttpStatusCode.Conflict)
        {

        }

        public InvalidPasswordException(string message, Exception inner) : base(message, inner, HttpStatusCode.Conflict)
        {

        }
    }
}

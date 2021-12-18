using System;
using System.Net;

namespace UserManagementService.Exceptions
{
    public class UsernameAlreadyTakenException : WebApiException
    {
        public UsernameAlreadyTakenException() : base(HttpStatusCode.Conflict)
        {

        }

        public UsernameAlreadyTakenException(string message) : base(message, HttpStatusCode.Conflict)
        {

        }

        public UsernameAlreadyTakenException(string message, Exception inner) : base(message, inner, HttpStatusCode.Conflict)
        {

        }
    }
}

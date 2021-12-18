using System;
using System.Net;

namespace UserManagementService.Exceptions
{
    public class WrongSecretAnswerException : WebApiException
    {
        public WrongSecretAnswerException() : base(HttpStatusCode.Conflict)
        {

        }

        public WrongSecretAnswerException(string message) : base(message, HttpStatusCode.Conflict)
        {

        }

        public WrongSecretAnswerException(string message, Exception inner) : base(message, inner, HttpStatusCode.Conflict)
        {

        }
    }
}

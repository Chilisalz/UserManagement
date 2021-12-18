using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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

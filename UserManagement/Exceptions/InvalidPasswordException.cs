using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class InvalidPasswordException : WebApiException
    {
        public InvalidPasswordException():base(HttpStatusCode.Conflict)
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

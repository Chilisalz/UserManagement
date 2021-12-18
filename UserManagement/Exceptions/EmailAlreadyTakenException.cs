using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class EmailAlreadyTakenException : WebApiException
    {
        public EmailAlreadyTakenException() : base(HttpStatusCode.Conflict)
        {

        }

        public EmailAlreadyTakenException(string message) : base(message, HttpStatusCode.Conflict)
        {

        }

        public EmailAlreadyTakenException(string message, Exception inner) : base(message, inner, HttpStatusCode.Conflict)
        {

        }

    }
}

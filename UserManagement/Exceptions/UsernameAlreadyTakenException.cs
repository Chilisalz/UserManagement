using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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

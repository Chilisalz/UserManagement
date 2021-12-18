using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class RefreshTokenAlreadyUsedException : WebApiException
    {
        public RefreshTokenAlreadyUsedException():base(HttpStatusCode.Conflict)
        {

        }

        public RefreshTokenAlreadyUsedException(string message) : base(message, HttpStatusCode.Conflict)
        {

        }

        public RefreshTokenAlreadyUsedException(string message, Exception inner) : base(message, inner, HttpStatusCode.Conflict)
        {

        }
    }
}

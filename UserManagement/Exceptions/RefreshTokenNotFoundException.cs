using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class RefreshTokenNotFoundException : WebApiException
    {
        public RefreshTokenNotFoundException():base(HttpStatusCode.NotFound)
        {

        }

        public RefreshTokenNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {

        }

        public RefreshTokenNotFoundException(string message, Exception inner) : base(message, inner, HttpStatusCode.NotFound)
        {

        }
    }
}

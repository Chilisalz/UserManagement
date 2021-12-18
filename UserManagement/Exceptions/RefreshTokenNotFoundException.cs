using System;
using System.Net;

namespace UserManagementService.Exceptions
{
    public class RefreshTokenNotFoundException : WebApiException
    {
        public RefreshTokenNotFoundException() : base(HttpStatusCode.NotFound)
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

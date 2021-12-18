using System;
using System.Net;

namespace UserManagementService.Exceptions
{
    public abstract class WebApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public WebApiException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public WebApiException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public WebApiException(string message, Exception inner, HttpStatusCode statusCode) : base(message, inner)
        {
            StatusCode = statusCode;
        }
    }
}

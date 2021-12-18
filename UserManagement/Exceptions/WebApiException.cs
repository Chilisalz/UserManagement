using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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

using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UserManagementService.Contracts.Responses;
using UserManagementService.Exceptions;

namespace UserManagementService.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                HttpResponse response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    WebApiException e => (int)e.StatusCode,// custom application error
                    _ => (int)HttpStatusCode.InternalServerError,// unhandled error
                };

                JsonSerializerOptions options = new();
                options.Converters.Add(new JsonStringEnumConverter());
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

                string result = System.Text.Json.JsonSerializer.Serialize(new ChiliResponse<object>()
                {
                    Status = ResponseStatus.error,
                    Errors = new[] { error.Message }
                }, options);

                await response.WriteAsync(result);
            }
        }
    }
}

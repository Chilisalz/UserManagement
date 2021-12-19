using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UserManagementService.Exceptions;
using UserManagementService.Responses;

namespace UserManagementService.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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

                _logger.LogError(error,
                      $"Request {context.Request?.Method}: {context.Request?.Path.Value} failed");

                await response.WriteAsync(result);
            }
        }
    }
}

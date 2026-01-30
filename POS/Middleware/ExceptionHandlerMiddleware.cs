using POS.Core.Application.Exceptions;
using POS.Core.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace POS.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = string.Empty;

            switch (exception)
            {
                case NotFoundException notFoundEx:
                    statusCode = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new { 
                        Message = notFoundEx.Message,
                        ErrorType = "NotFound"
                    });
                    break;
                case ValidationErrorException validationEx:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new { 
                        Message = "Validation failed",
                        Errors = validationEx.Errors 
                    });
                    break;
                case BusinessRuleException businessEx:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new { 
                        Message = businessEx.Message,
                        ErrorType = "BusinessRuleViolation"
                    });
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    result = JsonSerializer.Serialize(new { 
                        Message = "Internal server error",
                        ErrorType = "InternalServerError"
                    });
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}

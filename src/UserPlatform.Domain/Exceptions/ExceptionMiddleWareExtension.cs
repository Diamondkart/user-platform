using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using UserPlatform.Domain.Exceptions;

namespace ExceptionHandling.CustomMiddlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            RecordAlreadyExistsException => StatusCodes.Status409Conflict,
            NotImplementedException => StatusCodes.Status501NotImplemented,
            UnauthorizedAccessException => StatusCodes.Status501NotImplemented,
            ApplicationException => StatusCodes.Status401Unauthorized,
            NotFoundException => StatusCodes.Status404NotFound,
            BadRequestException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, $"An exception occurred, exception context: {context}");
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = GetStatusCode(exception);
            var errorResponse = new ErrorResponse { Message = exception.Message ?? $"Exception occured." };
            var result = JsonSerializer.Serialize(new { errors = errorResponse });
            await context.Response.WriteAsync(result);
        }
    }
}
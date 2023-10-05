using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using UserPlatform.Domain.Constant;
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

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var errorResponse = new ErrorResponse();

            switch (exception)
            {
                case RecordAlreadyExistsException ex:
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    errorResponse.Message = Constant.RecordExistsErrorMessage;
                    break;

                case NotImplementedException ex:
                    context.Response.StatusCode = StatusCodes.Status501NotImplemented;
                    errorResponse.Message = Constant.NotImplementedErrorMessage;
                    break;

                case UnauthorizedAccessException ex:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    errorResponse.Message = Constant.UnAuthorizeErrorMessage;
                    break;

                case ApplicationException ex:
                    if (ex.Message.Contains(Constant.InvalidTokenKey))
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        errorResponse.Message = ex.Message;
                        break;
                    }
                    errorResponse.Message = ex.Message;
                    break;

                default:
                    errorResponse.Message = Constant.InternalServerErrorMessage;
                    break;
            }

            _logger.LogError(exception, "An exception occurred.");

            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
        }
    }
}
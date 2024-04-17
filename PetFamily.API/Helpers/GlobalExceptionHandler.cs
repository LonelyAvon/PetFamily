using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace PetFamily.API.Helpers;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var exceptionMessage = exception.Message;

        _logger.LogError(
            "Error Message: {exceptionMessage}, Time of occurrence {time}",
            exceptionMessage, DateTime.UtcNow);

        var response = new Response
        {
            Code = "value.invalid",
            Message = exceptionMessage
        };

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }

    public class Response
    {
        public string Code { get; set; }

        public string Message { get; set; }
    }
}
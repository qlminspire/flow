using Microsoft.AspNetCore.Diagnostics;

namespace Flow.Api.Exceptions;

internal sealed class ExceptionLoggingHandler : IExceptionHandler
{
    private readonly ILogger<ExceptionLoggingHandler> _logger;

    public ExceptionLoggingHandler(ILogger<ExceptionLoggingHandler> logger)
    {
        _logger = logger;
    }

    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Request with TraceId {TraceId} failed with message: {ExceptionMessage}",
            httpContext.TraceIdentifier, exception.Message);

        return ValueTask.FromResult(false);
    }
}
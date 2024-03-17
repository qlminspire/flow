using Microsoft.AspNetCore.Diagnostics;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;
using ValidationException = FluentValidation.ValidationException;

namespace Flow.Api.Exceptions;

public sealed class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
            return false;

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        var validationErrors = GetValidationErrorsDictionary(validationException);
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = httpContext.Response.StatusCode,
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Extensions = validationErrors
        }, cancellationToken);

        return true;
    }

    private static Dictionary<string, object?> GetValidationErrorsDictionary(ValidationException exception)
    {
        var validationErrorDetails = exception.Errors
            .Select(x => new ValidationErrorDetails(x.PropertyName, x.ErrorCode, x.ErrorMessage))
            .ToList();

        var validationErrors = new ValidationErrors
        {
            Errors = validationErrorDetails
        };

        return validationErrors.GetType().GetProperties()
            .ToDictionary(property => property.Name.ToLowerInvariant(),
                property => property.GetValue(validationErrors));
    }
}
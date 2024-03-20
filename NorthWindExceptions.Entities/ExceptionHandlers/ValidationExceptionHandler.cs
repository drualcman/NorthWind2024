namespace NorthWindExceptions.Entities.ExceptionHandlers;
internal class ValidationExceptionHandler : Microsoft.AspNetCore.Diagnostics.IExceptionHandler
{

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        bool handled = false;

        if(exception is ValidationException ex)
        {
            ProblemDetails details = new ProblemDetails();

            details.Status = StatusCodes.Status400BadRequest;
            details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            details.Title = ExceptionMessages.ValidationExceptionTitle;
            details.Detail = ExceptionMessages.ValidationExceptionDetail;
            details.Instance = $"{nameof(ProblemDetails)}/{nameof(ValidationException)}";
            details.Extensions.Add("errors", ex.Errors);

            await httpContext.WriteProblemDetailsAsync(details);

            handled = true;
        }

        return handled;
    }
}

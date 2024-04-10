namespace NorthWind.Exceptions.Entities.ExceptionHandlers;
internal class UnauthorizedAccessExceptionHandler(ILogger<UnhandledExceptionHandler> Logger) : Microsoft.AspNetCore.Diagnostics.IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        bool handled = false;

        if (exception is UnauthorizedAccessException ex)
        {
            ProblemDetails details = new ProblemDetails();

            details.Status = StatusCodes.Status401Unauthorized;
            details.Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1";
            details.Title = ExceptionMessages.UnauthorizedAccessExceptionTitle;
            details.Detail = ExceptionMessages.UnauthorizedAccessExceptionDetail;
            details.Instance = $"{nameof(ProblemDetails)}/{nameof(UnauthorizedAccessException)}";

            Logger.LogError(exception, ExceptionMessages.UnauthorizedAccessExceptionTitle);

            await httpContext.WriteProblemDetailsAsync(details);

            handled = true;
        }

        return handled;
    }
}

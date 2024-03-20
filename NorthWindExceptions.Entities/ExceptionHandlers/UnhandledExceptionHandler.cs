namespace NorthWind.Exceptions.Entities.ExceptionHandlers;
internal class UnhandledExceptionHandler(ILogger<UnhandledExceptionHandler> Logger) : Microsoft.AspNetCore.Diagnostics.IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ProblemDetails details = new ProblemDetails();

        details.Status = StatusCodes.Status503ServiceUnavailable;
        details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.4";
        details.Title = ExceptionMessages.UnhandledExceptionTitle;
        details.Detail = ExceptionMessages.UnhandledExceptionDetail;
        details.Instance = $"{nameof(ProblemDetails)}/{exception.GetType().Name}";
        
        Logger.LogError(exception, ExceptionMessages.UnhandledExceptionTitle);

        await httpContext.WriteProblemDetailsAsync(details);
        return true;
    }
}

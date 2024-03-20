
namespace NorthWindExceptions.Entities.ExceptionHandlers;
internal class UpdateExceptionHandler(ILogger<UpdateExceptionHandler> Logger) : Microsoft.AspNetCore.Diagnostics.IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        bool handled = false;

        if(exception is UpdateException ex)
        {
            ProblemDetails details = new ProblemDetails();

            details.Status = StatusCodes.Status500InternalServerError;
            details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
            details.Title = ExceptionMessages.UpdateExceptionTitle;
            details.Detail = ExceptionMessages.UpdateExceptionDetail;
            details.Instance = $"{nameof(ProblemDetails)}/{nameof(UpdateException)}";

            Logger.LogError(exception, ExceptionMessages.UpdateExceptionTitle + ":" + string.Join(' ', ex.Entities));

            await httpContext.WriteProblemDetailsAsync(details);

            handled = true;
        }

        return handled;
    }
}

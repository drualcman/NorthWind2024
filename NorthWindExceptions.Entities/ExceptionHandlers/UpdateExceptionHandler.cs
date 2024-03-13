namespace NorthWindExceptions.Entities.ExceptionHandlers;
internal class UpdateExceptionHandler(ILogger<UpdateExceptionHandler> Logger) : IExceptionHandler<UpdateException>
{
    public ProblemDetails Handle(UpdateException exception)
    {
        ProblemDetails details = new ProblemDetails();

        details.Status = StatusCodes.Status500InternalServerError;
        details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
        details.Title = ExceptionMessages.UpdateExceptionTitle;
        details.Detail = ExceptionMessages.UpdateExceptionDetail;
        details.Instance = $"{nameof(ProblemDetails)}/{nameof(UpdateException)}";

        Logger.LogError(exception, ExceptionMessages.UpdateExceptionTitle + ":" + string.Join(' ', exception.Entities));

        return details;
    }
}

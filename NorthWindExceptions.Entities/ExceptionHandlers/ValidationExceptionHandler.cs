namespace NorthWindExceptions.Entities.ExceptionHandlers;
internal class ValidationExceptionHandler : IExceptionHandler<ValidationException>
{
    public ProblemDetails Handle(ValidationException exception)
    {
        ProblemDetails details = new ProblemDetails();

        details.Status = StatusCodes.Status400BadRequest;
        details.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        details.Title = ExceptionMessages.ValidationExceptionTitle;
        details.Detail = ExceptionMessages.ValidationExceptionDetail;
        details.Instance = $"{nameof(ProblemDetails)}/{nameof(ValidationException)}";
        details.Extensions.Add("errors", exception.Errors);

        return details;
    }
}

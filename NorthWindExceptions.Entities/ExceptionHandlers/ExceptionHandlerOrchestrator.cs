
namespace NorthWindExceptions.Entities.ExceptionHandlers;
internal class ExceptionHandlerOrchestrator : Microsoft.AspNetCore.Diagnostics.IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

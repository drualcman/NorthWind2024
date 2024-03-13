namespace NorthWindExceptions.Entities.Interfaces;
public interface IExceptionHandler<T> where T : Exception
{
    ProblemDetails Handle(T Exception);
}

using NorthWind.Exceptions.Entities.Exceptions;

namespace NorthWind.Sales.Backend.BusinessObjects.Guards;
public static class GuardModel
{
    public static async Task AgainstNotValid<T>(
        IModelValidatorHub<T> modelValuidatorHub, T model)
    {
        if(!await modelValuidatorHub.Validate(model))
            throw new ValidationException(modelValuidatorHub.Errors);
    }
}

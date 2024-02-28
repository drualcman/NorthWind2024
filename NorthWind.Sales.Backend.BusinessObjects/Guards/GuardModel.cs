namespace NorthWind.Sales.Backend.BusinessObjects.Guards;
public static class GuardModel
{
    public static async Task AgainstNotValid<T>(
        IModelValidatorHub<T> modelValuidatorHub, T model)
    {
        if(await modelValuidatorHub.Validate(model))
        {
            string errors = string.Join(" ", modelValuidatorHub.Errors
                .Select(e => $"{e.PropertyName}: {e.Message}"));
            throw new Exception(errors);
        }
    }
}

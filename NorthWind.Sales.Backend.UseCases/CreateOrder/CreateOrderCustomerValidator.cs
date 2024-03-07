namespace NorthWind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderCustomerValidator(IQueriesRepository Repository) : IModelValidator<CreateOrderDto>
{
    readonly List<ValidationError> ErrorsField = [];
    public ValidationConstraint Constraint => ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

    public IEnumerable<ValidationError> Errors => ErrorsField;

    public async Task<bool> Validate(CreateOrderDto model)
    {
        decimal? currentBallance = await Repository.GetCustomerCurrentBallance(model.CustomerId);
        
        if (currentBallance == null) 
        {
            ErrorsField.Add(new ValidationError(
                nameof(model.CustomerId),
                CreateOrderMessages.CustomerIdNotFoundError
                ));
        }
        else if (currentBallance > 0)
        {
            ErrorsField.Add(new ValidationError(
                nameof(model.CustomerId),
                string.Format(CreateOrderMessages.CustomerWithBalanceErrorTemplate, 
                              model.CustomerId, currentBallance)
                ));
        }

        return !ErrorsField.Any();
    }
}

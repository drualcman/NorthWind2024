namespace NorthWind.Sales.Validators.Entities.CreateOrder;

internal class CreateOrderDtoValidator :
    AbstractModelValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator(IValidationService<CreateOrderDto> validationService,
        IModelValidator<CreateOrderDetailDto> detailValidator) 
        : base(validationService)
    {
        AddRuleFor(c => c.CustomerId)
            .NotEmpty(CreateOrderMessages.CustomerIdRequired)
            .Length(5, CreateOrderMessages.CustomerIdRequiredLengh);

        AddRuleFor(c => c.ShipAddress)
            .NotEmpty(CreateOrderMessages.ShipAddressRequired)
            .MaximumLength(60, CreateOrderMessages.ShipAddressMaximumLenght);

        AddRuleFor(c => c.ShipCity)
            .NotEmpty(CreateOrderMessages.ShipCityRequired)
            .MinimumLength(3, CreateOrderMessages.ShipCityMinimumLenght)
            .MaximumLength(15, CreateOrderMessages.ShipCityMaximumLenght);
        
        AddRuleFor(c => c.ShipCountry)
            .NotEmpty(CreateOrderMessages.ShipCountryRequired)
            .MinimumLength(3, CreateOrderMessages.ShipCountryMinimumLenght)
            .MaximumLength(15, CreateOrderMessages.ShipCountryMaximumLenght);

        AddRuleFor(c => c.ShipPostalcode)
            .MaximumLength(10, CreateOrderMessages.ShipPostalCodeMaximumLenght);

        AddRuleFor(c => c.OrderDetails)
            .NotNull(CreateOrderMessages.OrdersDetailsRequiered)
            .NotEmpty(CreateOrderMessages.OrderDetailsNotEmpty);

        AddRuleForEach(d => d.OrderDetails)
            .SetValidator(detailValidator);

    }
}

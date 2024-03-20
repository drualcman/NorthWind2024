using NorthWind.Razor.Components.Validators;
using NorthWind.Validation.Entities.ValueObjects;

namespace NorthWind.Sales.Frontend.Views.ViewModels.CreateOrder;
public class CreateOrderViewModel(ICreateOrderGateway Gateway, IModelValidatorHub<CreateOrderViewModel> validatorHub)
{
    public ModelValidator<CreateOrderViewModel> ModelValidatorComponentReference { get; set; }
    public IModelValidatorHub<CreateOrderViewModel> Validator => validatorHub;

    public string CustomerId { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipPostalcode { get; set; }
    public List<CreateOrderDetailViewModel> OrderDetails { get; set; } = [];

    public string InformationMessage { get; private set; }
    public void AddNewOrderDetailItem()
    {
        OrderDetails.Add(new CreateOrderDetailViewModel());
    }

    public async Task Send()
    {
        InformationMessage = string.Empty;
        try
        {
            int orderId = await Gateway.CreateOrderAsync(
                (CreateOrderDto)this);
            InformationMessage = string.Format(CreateOrderMessages.CreateOrderTemplate, orderId);
        }
        catch (HttpRequestException ex)
        {
            if (ex.Data.Contains("Errors"))
            {
                IEnumerable<ValidationError> errors = ex.Data["Errors"] as IEnumerable<ValidationError>;
                ModelValidatorComponentReference.AddErrors(errors);
                InformationMessage = ex.Message;
            }
            else
            {
                throw;
            }
        } 
    }

    public static explicit operator CreateOrderDto(CreateOrderViewModel model) =>
        new CreateOrderDto(model.CustomerId, model.ShipAddress, model.ShipCity, model.ShipCountry, model.ShipPostalcode,
            model.OrderDetails.Select(d => new CreateOrderDetailDto(d.ProductId, d.UnitPrice, d.Quantity)));
}

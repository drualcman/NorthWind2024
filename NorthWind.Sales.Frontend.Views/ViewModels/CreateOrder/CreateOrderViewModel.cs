namespace NorthWind.Sales.Frontend.Views.ViewModels.CreateOrder;
public class CreateOrderViewModel(ICreateOrderGateway Gateway)
{
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
        int orderId = await Gateway.CreateOrderAsync(
            (CreateOrderDto)this);
        InformationMessage = string.Format(CreateOrderMessages.CreateOrderTemplate, orderId);
    }

    public static explicit operator CreateOrderDto(CreateOrderViewModel model) =>
        new CreateOrderDto(model.CustomerId, model.ShipAddress, model.ShipCity, model.ShipCountry, model.ShipPostalcode,
            model.OrderDetails.Select(d => new CreateOrderDetailDto(d.ProductId, d.UnitPrice, d.Quantity)));
}

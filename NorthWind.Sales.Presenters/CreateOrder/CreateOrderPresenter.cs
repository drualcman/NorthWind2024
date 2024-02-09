namespace NorthWind.Sales.Backend.Presenters.CreateOrder;

public class CreateOrderPresenter : ICreateOrderOutputPort
{
    public int OrderID { get; private set; }

    public Task Handle(OrderAgregate addedOrder)
    {
        OrderID = addedOrder.Id;
        return Task.CompletedTask;
    }
}

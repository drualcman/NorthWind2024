namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;
public interface ICreateOrderOutputPort
{
    int OrderID { get; }
    Task Handle(OrderAgregate addedOrder);
}

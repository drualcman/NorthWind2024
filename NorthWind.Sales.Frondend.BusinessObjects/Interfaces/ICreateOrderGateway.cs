namespace NorthWind.Sales.Frondend.BusinessObjects.Interfaces;

public interface ICreateOrderGateway
{
     Task<int> CreateOrderAsync(CreateOrderDto order);
}

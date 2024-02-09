namespace NorthWind.Sales.Bacnkend.Repositories.Interfaces;
public interface INorthWindSalesCommandsDataContext
{
    Task AddOrderAsync(Order order);
    Task AddOrderDetailsAsync(IEnumerable<Entities.OrderDetail> orderDetails);
    Task SaveChangesAsync();
}

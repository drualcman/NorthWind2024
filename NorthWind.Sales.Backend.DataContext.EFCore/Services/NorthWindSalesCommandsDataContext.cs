namespace NorthWind.Sales.Backend.DataContext.EFCore.Services;
internal class NorthWindSalesCommandsDataContext(NorthWindSalesContext DbContext) : INorthWindSalesCommandsDataContext
{       

    public async Task AddOrderAsync(Order order)
    {
        await DbContext.Orders.AddAsync(order);
    }

    public async Task AddOrderDetailsAsync(IEnumerable<OrderDetail> orderDetails)
    {
        await DbContext.OrderDetails.AddRangeAsync(orderDetails);
    }

    public async Task SaveChangesAsync()
    {
        await DbContext.AddRangeAsync();
    }
}

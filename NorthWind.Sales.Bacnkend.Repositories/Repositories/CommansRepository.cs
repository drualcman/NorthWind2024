using NorthWind.Sales.Backend.Repositories.Interfaces;

namespace NorthWind.Sales.Backend.Repositories.Repositories;
internal class CommansRepository(INorthWindSalesCommandsDataContext Context) : ICommandsRepository
{
    public async Task CreateOrder(OrderAgregate order)
    {
        await Context.AddOrderAsync(order);
        await Context.AddOrderDetailsAsync(order.OrderDetails.Select(d => new Entities.OrderDetail
        {
            Order = order,
            ProductId = d.ProductId,
            Quantity = d.Quantity,
            UnitPrice = d.UnitPrice
        }).ToArray());
    }

    public async Task SaveChanges() => await Context.SaveChangesAsync();
}

namespace NorthWind.Sales.Backend.Repositories.Interfaces;
public interface INorthWindSalesQueriesDataContext
{
    IQueryable<Customer> Customers { get; }
    IQueryable<Product> Products { get; }
    Task<ReturnType> FirstOrDefaultAsync<ReturnType>(IQueryable<ReturnType> query);
    Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(IQueryable<ReturnType> query);
}

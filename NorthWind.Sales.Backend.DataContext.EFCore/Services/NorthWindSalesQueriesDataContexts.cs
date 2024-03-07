namespace NorthWind.Sales.Backend.DataContext.EFCore.Services;
internal class NorthWindSalesQueriesDataContexts : NorthWindSalesContext, INorthWindSalesQueriesDataContext
{
    public NorthWindSalesQueriesDataContexts(IOptions<DbOptions> DbOptions) : base(DbOptions)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public new IQueryable<Customer> Customers => base.Customers;

    public new IQueryable<Product> Products => base.Products;

    public Task<ReturnType> FirstOrDefaultAsync<ReturnType>(IQueryable<ReturnType> queryable)
        => queryable.FirstOrDefaultAsync();

    public async Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(IQueryable<ReturnType> queryable)
        => await queryable.ToListAsync();
}

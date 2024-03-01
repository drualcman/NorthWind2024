namespace NorthWind.Sales.Backend.Repositories.Repositories;
internal class QueriesRepository(INorthWindSalesQueriesDataContext Context) : IQueriesRepository
{
    public async Task<decimal?> GetCustomerCurrentBallance(string customerId)
    {
        var queriable = Context.Customers
            .Where(c => c.Id == customerId)
            .Select(c => new { c.CurrentBallance });

        var result = await Context.FirstOrDefaultAsync(queriable);
        return result?.CurrentBallance;
    }

    public async Task<IEnumerable<ProductUnitsInStock>> GetProductsUnitsInStockAsync(IEnumerable<int> productId)
    {
        throw new NotImplementedException();
    }
}

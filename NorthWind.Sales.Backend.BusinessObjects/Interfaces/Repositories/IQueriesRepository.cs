namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Repositories;
public interface IQueriesRepository
{
    Task<IEnumerable<ProductUnitsInStock>> GetProductsUnitsInStockAsync(IEnumerable<int> productId);
    Task<decimal?> GetCustomerCurrentBallance(string customerId);
}

using NorthWind.Sales.Backend.BusinessObjects.POCOEntities;
using NorthWind.Sales.Backend.BusinessObjects.ValueObjects;

namespace NorthWind.Sales.Backend.BusinessObjects.Agregates;
public class OrderAgregate : Order
{
    readonly List<OrderDetail> OrderDetailsField = [];
    public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField;
    public void AddDetail(int productId, decimal unitPrice, short quantity)
    {

    }

}

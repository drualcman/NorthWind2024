namespace NorthWind.Sales.Backend.BusinessObjects.Agregates;
public class OrderAgregate : Order
{
    readonly List<OrderDetail> OrderDetailsField = [];
    public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField;
    public void AddDetail(int productId, decimal unitPrice, short quantity)
    {
        OrderDetail existingOrderDetail = OrderDetailsField.FirstOrDefault(o=> o.ProductId == productId);
        if (existingOrderDetail != default)
        {
            quantity += existingOrderDetail.Quantity;
            OrderDetailsField.Remove(existingOrderDetail);
        }
        OrderDetailsField.Add(new OrderDetail(productId, unitPrice, quantity));
    }

    public static OrderAgregate From(CreateOrderDto orderDto)
    {
        OrderAgregate orderAgregate = new OrderAgregate
        {
            CustomerId = orderDto.CustomerId,
            ShipAddress = orderDto.ShipAddress,
            ShipCity = orderDto.ShipCity,
            ShipCountry = orderDto.ShipCountry,
            ShipPostalcode = orderDto.ShipPostalcode            
        };
        foreach (CreateOrderDetailDto item in orderDto.OrderDetails)
        {
            orderAgregate.AddDetail(item.ProductId, item.UnitPrice, item.Quantity);
        }
        return orderAgregate;
    }
}

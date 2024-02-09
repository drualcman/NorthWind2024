namespace NorthWind.Sales.Bacnkend.Repositories.Entities;
public class OrderDetail
{
    public int OrderID { get; set; }
    public Order Order { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public short Quantity { get; set; }


}

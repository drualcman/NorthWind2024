namespace NorthWind.Sales.Backend.Repositories.Entities;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public short UnitInStock { get; set; }
    public decimal Price { get; set; }

}

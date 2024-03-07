
namespace NorthWind.Sales.Backend.DataContext.EFCore.Configurations;
internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p=> p.Name)
            .IsRequired()
            .HasMaxLength(40);
        builder.Property(p => p.UnitPrice)
            .HasPrecision(8, 2);
        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Chai",
                UnitPrice = 35,
                UnitInStock = 20
            },
            new Product
            {
                Id = 2,
                Name = "Chang",
                UnitPrice = 55,
                UnitInStock = 0
            },
            new Product
            {
                Id = 3,
                Name = "Anised Syrup",
                UnitPrice = 65,
                UnitInStock = 20
            },
            new Product
            {
                Id = 4,
                Name = "Chef Anton's",
                UnitPrice = 75,
                UnitInStock = 40
            },
            new Product
            {
                Id = 5,
                Name = "Gumbo Mix",
                UnitPrice = 50,
                UnitInStock = 20
            });
    }
}

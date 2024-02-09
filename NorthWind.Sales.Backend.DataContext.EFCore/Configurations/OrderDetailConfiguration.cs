namespace NorthWind.Sales.Backend.DataContext.EFCore.Configurations;
internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(d => new { d.OrderID, d.ProductId });
        
        builder.Property(d => d.UnitPrice)
            .HasPrecision(8, 2);
    }
}

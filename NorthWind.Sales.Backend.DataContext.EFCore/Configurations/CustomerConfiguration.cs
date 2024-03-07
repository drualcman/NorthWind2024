namespace NorthWind.Sales.Backend.DataContext.EFCore.Configurations;
internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.Id)
            .HasMaxLength(5)
            .IsFixedLength();
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(40);
        builder.Property(c => c.CurrentBallance)
            .HasPrecision(8, 2);
        builder.HasData(
            new Customer
            {
                Id = "ALFKI",
                Name = "Alfreds Futterkiste",
                CurrentBallance = 0
            },
            new Customer
            {
                Id = "ANATR",
                Name = "Ana Trujillo",
                CurrentBallance = 0
            },
            new Customer
            {
                Id = "ANTON",
                Name = "Antonio Moreno",
                CurrentBallance = 100
            });
    }
}

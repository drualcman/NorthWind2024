namespace NorthWind.Sales.Backend.DataContext.EFCore.DataContexts;
/// <summary>
/// add-migration InitialCreate -p NorthWind.Sales.Backend.DataContext.EFCore -s NorthWind.Sales.Backend.DataContext.EFCore -c NorthWindContext
/// update-database -p NorthWind.Sales.Backend.DataContext.EFCore -s NorthWind.Sales.Backend.DataContext.EFCore -context NorthWindContext
/// </summary>
internal class NorthWindContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;DataBase=NorthWindDb2024");
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}


namespace NorthWind.Sales.Backend.DataContext.EFCore.DataContexts;
internal class NorthWindDomainLogsContext(IOptions<DbOptions> DbOptions) : DbContext
{
    public DbSet<DomainLog> DomainLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DbOptions.Value.DomainLogsConnectionString);
    }
}

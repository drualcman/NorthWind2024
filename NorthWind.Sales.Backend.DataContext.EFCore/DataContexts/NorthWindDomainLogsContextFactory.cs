using Microsoft.EntityFrameworkCore.Design;

namespace NorthWind.Sales.Backend.DataContext.EFCore.DataContexts;
/// <summary>
/// Add-Migration InitialCreate -p NorthWind.Sales.Backend.DataContext.EFCore -s NorthWind.Sales.Backend.DataContext.EFCore -c NorthWindDomainLogsContext
/// Update-Database -p NorthWind.Sales.Backend.DataContext.EFCore -s NorthWind.Sales.Backend.DataContext.EFCore -context NorthWindDomainLogsContext
/// </summary>
internal class NorthWindDomainLogsContextFactory : IDesignTimeDbContextFactory<NorthWindDomainLogsContext>
{
    public NorthWindDomainLogsContext CreateDbContext(string[] args)
    {
        IOptions<DbOptions> DBOptions =
            Microsoft.Extensions.Options.Options.Create(
            new DbOptions
            {
                DomainLogsConnectionString = "Server=(localdb)\\mssqllocaldb;DataBase=NorthWindLogsDb"
            });
        return new NorthWindDomainLogsContext(DBOptions);
    }
}

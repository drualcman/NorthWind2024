
namespace NorthWind.Sales.Backend.DataContext.EFCore.Services;
internal class NorthWindDomainLogsDataContext(IOptions<DbOptions> DbOptions) : NorthWindDomainLogsContext(DbOptions), INorthWindDomainLogsDataContext
{
    public async Task AddLogAsync(DomainLog log) =>
        await AddAsync(log);

    public Task SaveChangesAsync() =>
        base.SaveChangesAsync();
}

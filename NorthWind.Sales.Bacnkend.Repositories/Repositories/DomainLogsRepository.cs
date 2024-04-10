namespace NorthWind.Sales.Backend.Repositories.Repositories;
internal class DomainLogsRepository(INorthWindDomainLogsDataContext Context) : IDomainLogsRepository
{
    public async Task Add(DomainLogs.Entities.ValueObjects.DomainLog log)
    {
        await Context.AddLogAsync(new DomainLog
        {
            CreatedDate = log.DateTime,
            Information = log.Information,
            UserName = log.UserName
        });
    }

    public async Task SaveChanges() =>
        await Context.SaveChangesAsync();
}

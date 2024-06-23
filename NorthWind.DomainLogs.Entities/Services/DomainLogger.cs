namespace NorthWind.DomainLogs.Entities.Services;
internal class DomainLogger(IDomainLogsRepository Repository) : IDomainLogger
{
    public async Task LogInformation(DomainLog log)
    {
        await Repository.Add(log);
        await Repository.SaveChanges();
    }
}

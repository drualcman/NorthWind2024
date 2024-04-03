namespace NorthWind.DomainLogs.Entities.ValueObjects;
public class DomainLog(string information)
{
    public DateTime DateTime => DateTime.Now;
    public string Information => information;
}

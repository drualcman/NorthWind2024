namespace NorthWind.Sales.Backend.DataContext.EFCore.Options;
public class DbOptions
{
    public const string SectionKey = nameof(DbOptions);

    public string ConnectionString { get; set; }
}

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddDbContexts(this IServiceCollection services)
    {
        services.AddDbContext<NorthWindSalesContext>();
        services.AddScoped<INorthWindSalesCommandsDataContext, NorthWindSalesCommandsDataContext>();
        return services;
    }
}

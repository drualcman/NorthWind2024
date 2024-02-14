namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddDataContexts(this IServiceCollection services, 
        Action<DbOptions> configureDbOptions)
    {
        services.Configure<DbOptions>(configureDbOptions);
        services.AddScoped<INorthWindSalesCommandsDataContext, NorthWindSalesCommandsDataContext>();
        return services;
    }
}

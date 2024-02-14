namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddBackendServices(this IServiceCollection services,
        Action<DbOptions> configureDbOptions)
    {
        services
            .AddSalesUseCases()
            .AddRepositories()
            .AddDataContexts(configureDbOptions)
            .AddPresenters();
        return services;
    }
}

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICommandsRepository, CommansRepository>();
        services.AddScoped<IQueriesRepository, QueriesRepository>();
        return services;
    }
}

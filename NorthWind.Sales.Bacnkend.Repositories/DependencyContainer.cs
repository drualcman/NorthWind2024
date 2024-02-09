using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.Backend.Repositories.Repositories;

namespace NorthWind.Sales.Backend.Repositories;
public static class DependencyContainer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICommandsRepository, CommansRepository>();
        return services;
    }
}

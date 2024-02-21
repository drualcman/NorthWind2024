using NorthWind.Sales.Frontend.BusinessObjects.Interfaces;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddWebApiGateways(this IServiceCollection services,
        Action<HttpClient> configureHttpClient)
    {
        services.AddHttpClient();
        services.AddHttpClient<ICreateOrderGateway, CreateOrderGateway>(configureHttpClient);
        return services;
    }
}

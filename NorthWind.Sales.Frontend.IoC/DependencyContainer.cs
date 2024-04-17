namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddNorthWindSalesServices(this IServiceCollection services,
        Action<HttpClient> configureHttpClient,
        Action<HttpClient> configureMembershipHttpClient)
    {
        services
            .AddWebApiGateways(configureHttpClient)
            .AddViewsServices()
            .AddValidators()
            .AddValidationService()
            .AddMembershipFrondendServices(configureMembershipHttpClient);
        return services;
    }
}

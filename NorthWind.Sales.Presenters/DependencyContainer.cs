using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.Backend.Presenters.CreateOrder;

namespace NorthWind.Sales.Backend.Presenters;
public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();
        return services;
    }
}

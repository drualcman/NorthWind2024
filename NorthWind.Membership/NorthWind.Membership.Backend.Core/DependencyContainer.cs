namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipCoreServices(this IServiceCollection services)
    {
        services.AddMembershipValidators();
        services.AddDefaultModelValidatorServices();
        services.AddScoped<IUserRegistrationInputPort, UserRegistrationInteractor>();
        services.AddScoped<IUserRegistrationOutputPort, UserRegistrationPresenter>();
        return services;
    }
}

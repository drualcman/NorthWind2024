namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipCoreServices(this IServiceCollection services,
        Action<JwtOptions> configureOptions)
    {
        services.AddMembershipValidators();
        services.AddDefaultModelValidatorServices();
        services.AddScoped<IUserRegistrationInputPort, UserRegistrationInteractor>();
        services.AddScoped<IUserRegistrationOutputPort, UserRegistrationPresenter>();
        services.AddScoped<IUserLoginInputPort, UserLoginInteractor>();
        services.Configure(configureOptions);
        services.AddSingleton<JwtService>();
        services.AddScoped<IUserLoginOutputPort, UserLoginPresenter>();
        return services;
    }
}

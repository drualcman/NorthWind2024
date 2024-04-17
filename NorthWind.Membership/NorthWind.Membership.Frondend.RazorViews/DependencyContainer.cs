namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipFrondendServices(this IServiceCollection services,
        Action<HttpClient> configureHttpClient)
    {
        services.AddExceptionDelegatingHandler();
        services.AddHttpClient();
        services.AddHttpClient<MembershipGateway>(configureHttpClient)
            .AddHttpMessageHandler<ExceptionDelegatingHandler>();
        services.AddMembershipValidators();
        services.AddModelValidator<UserRegistrationViewModel, UserRegistrationViewModelDtoValidator>();
        services.AddModelValidator<UserRegistrationViewModel, UerRegistratinoViewModelValidator>();
        services.AddScoped<UserRegistrationViewModel>();
        return services;
    }
}

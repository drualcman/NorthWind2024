namespace NorthWind.Membership.Frondend.RazorViews;

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
        services.AddModelValidator<UserLoginViewModel, UserLoginViewModelDtoValidator>();
        services.AddScoped<UserLoginViewModel>();
        return services;
    }
}

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddMailServices(this IServiceCollection services,
        Action<SmtpOptions> configureSmtpOptions)
    {
        services.Configure(configureSmtpOptions);
        services.AddSingleton<IMailService, MailService>();
        return services;
    }
}

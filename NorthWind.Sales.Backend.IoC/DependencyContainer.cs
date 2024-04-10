namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddNorthWindSalesServices(this IServiceCollection services,
        Action<DbOptions> configureDbOptions,
        Action<SmtpOptions> configureSmtpOptions)
    {
        services
            .AddSalesUseCases()
            .AddRepositories()
            .AddDataContexts(configureDbOptions)
            .AddPresenters()
            .AddValidators()
            .AddValidationService()
            .AddValidationExceptionHandler()
            .AddUpdateExceptionHandler()
            .AddUnauthorizedAccessExceptionHandler()
            .AddUnhandledExceptionHandler()
            .AddMailServices(configureSmtpOptions)
            .AddEventServices()
            .AddDomainLogsServices()
            .AddTransactionServices()
            .AddUserServices();
        return services;
    }
}

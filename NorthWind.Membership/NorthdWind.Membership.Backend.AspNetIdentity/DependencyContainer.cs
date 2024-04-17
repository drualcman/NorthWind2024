namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipIdentityServices(this IServiceCollection services, 
        Action<MembershipDbOptions> configureMembershipDbOptions)
    {
        services.Configure(configureMembershipDbOptions);
        services.AddDbContext<NorthWindMembershipContext>();
        services.AddIdentityCore<NothWindUser>()
            .AddEntityFrameworkStores<NorthWindMembershipContext>();
        services.AddScoped<IMembershipService, MembershipService>();
        return services;
    }
}

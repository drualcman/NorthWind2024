namespace NorthWind.Membership.Backend.AspNetIdentity.DataContexts;
internal class NorthWindMembershipContext(IOptions<MembershipDbOptions> options) :
    IdentityDbContext<NothWindUser>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(options.Value.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }
}

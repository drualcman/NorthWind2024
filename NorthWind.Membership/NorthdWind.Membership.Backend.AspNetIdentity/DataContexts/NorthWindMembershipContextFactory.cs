using Microsoft.EntityFrameworkCore.Design;

namespace NorthWind.Membership.Backend.AspNetIdentity.DataContexts;
internal class NorthWindMembershipContextFactory : IDesignTimeDbContextFactory<NorthWindMembershipContext>
{
    public NorthWindMembershipContext CreateDbContext(string[] args)
    {
        IOptions<MembershipDbOptions> options = Microsoft.Extensions.Options.Options.Create(
            new MembershipDbOptions
            {
                ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=NorthWinUserDb2024"
            });

        return new NorthWindMembershipContext(options);
    }
}

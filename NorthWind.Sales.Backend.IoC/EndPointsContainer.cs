namespace Microsoft.AspNetCore.Builder;
public static class EndPointsContainer
{
    public static WebApplication MapNorthWindSalesEndpoints(this WebApplication app)
    {
        app.UseCreateOrderController();
        return app;
    }
}

namespace Microsoft.AspNetCore.Builder;
public static class EndPointsContainer
{
    public static WebApplication MapAppEndpoints(this WebApplication app)
    {
        app.UseCreateOrderController();
        return app;
    }
}

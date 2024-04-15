using NorthWind.Membership.Entities.ValueObjects;

namespace Microsoft.AspNetCore.Builder;
internal static class UserRegistrationController
{
    public static WebApplication UseUserRegistration(this WebApplication app)
    {
        app.MapPost(Endpoints.Register, async (UserRegistrationDto userData, IUserRegistrationInputPort inputPort, IUserRegistrationOutputPort presenter) =>
        {
            await inputPort.Handle(userData);
            return presenter.Result;
        });
        return app;
    } 
}

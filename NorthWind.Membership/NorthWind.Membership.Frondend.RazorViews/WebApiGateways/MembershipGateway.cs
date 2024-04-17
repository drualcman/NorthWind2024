namespace NorthWind.Membership.Frondend.RazorViews.WebApiGateways;
public class MembershipGateway(HttpClient Client)
{
    public async Task RegisterAsync(UserRegistrationDto userData) =>
        await Client.PostAsJsonAsync(Endpoints.Register, userData);
}

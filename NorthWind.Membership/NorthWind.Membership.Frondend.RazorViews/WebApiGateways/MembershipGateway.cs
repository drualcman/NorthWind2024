using NorthWind.Membership.Entities.Dtos.UserLogin;

namespace NorthWind.Membership.Frondend.RazorViews.WebApiGateways;
public class MembershipGateway(HttpClient Client)
{
    public async Task RegisterAsync(UserRegistrationDto userData) =>
        await Client.PostAsJsonAsync(Endpoints.Register, userData);

    public async Task<TokensDto> LoginAsync(UserCredentialsDto userCredentials)
    {
        HttpResponseMessage response = await Client.PostAsJsonAsync(Endpoints.Login, userCredentials);
        return await response.Content.ReadFromJsonAsync<TokensDto>();
    }
}

namespace NorthWind.Sales.Frontend.WebApiGateways;

internal class CreateOrderGateway(HttpClient Client) : ICreateOrderGateway
{
    public async Task<int> CreateOrderAsync(CreateOrderDto order)
    {
        using HttpResponseMessage response = await Client.PostAsJsonAsync(EndPoints.CreateOrder, order);
        return await response.Content.ReadFromJsonAsync<int>();
    }
}

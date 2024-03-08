﻿namespace NorthWind.Sales.Frontend.WebApiGateways;

internal class CreateOrderGateway(HttpClient Client) : ICreateOrderGateway
{
    public async Task<int> CreateOrderAsync(CreateOrderDto order)
    {
        int orderId = 0;
        HttpResponseMessage response = await Client.PostAsJsonAsync(EndPoints.CreateOrder, order);
        if (response.IsSuccessStatusCode)
        {
            orderId = await response.Content.ReadFromJsonAsync<int>();
        }
        else
        {
            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }
        return orderId;
    }
}

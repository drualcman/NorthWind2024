namespace Microsoft.AspNetCore.Builder;

public static class CreateOrderController
{
    public static WebApplication UseCreateOrderController(this WebApplication app)
    {
        app.MapPost(EndPoints.CreateOrder, CreateOrder);
        return app;
    }

    public static async Task<int> CreateOrder(CreateOrderDto orderDto,
        ICreateOrderInputPort inputPort, ICreateOrderOutputPort presenter)
    {
        await inputPort.Handle(orderDto);
        return presenter.OrderID;
    }
}

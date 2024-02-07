namespace NorthWind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderInteractor(ICommandsRepository Repository, ICreateOrderOutputPort OutputPort) : ICreateOrderInputPort
{
    public async Task Handle(CreateOrderDto orderDto)
    {
        OrderAgregate order = OrderAgregate.From(orderDto);
        await Repository.CreateOrder(order);
        await Repository.SaveChanges();
        await OutputPort.Handle(order);
    }
}

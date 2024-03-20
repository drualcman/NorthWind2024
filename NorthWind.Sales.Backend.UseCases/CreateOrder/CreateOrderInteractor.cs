namespace NorthWind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderInteractor(
    ICreateOrderOutputPort OutputPort,
    ICommandsRepository Repository,
    IModelValidatorHub<CreateOrderDto> ModelValidatorHub
    ) : ICreateOrderInputPort
{
    public async Task Handle(CreateOrderDto orderDto)
    {
        await GuardModel.AgainstNotValid(ModelValidatorHub, orderDto);
        OrderAgregate order = OrderAgregate.From(orderDto);
        await Repository.CreateOrder(order);
        await Repository.SaveChanges();
        await OutputPort.Handle(order);
    }
}

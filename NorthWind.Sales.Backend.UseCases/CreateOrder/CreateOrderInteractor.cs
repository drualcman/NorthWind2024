namespace NorthWind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderInteractor(
    ICreateOrderOutputPort OutputPort,
    ICommandsRepository Repository,
    IModelValidatorHub<CreateOrderDto> ModelValidatorHub,
    IDomainEventHub<SpecialOrderCreatedEvent> DomainEventHub,
    IDomainLogger DomainLogger
    ) : ICreateOrderInputPort
{
    public async Task Handle(CreateOrderDto orderDto)
    {
        await GuardModel.AgainstNotValid(ModelValidatorHub, orderDto);

        await DomainLogger.LogInformation(new DomainLog(CreateOrderMessages.StartingPurchaseOrderCreation));

        OrderAgregate order = OrderAgregate.From(orderDto);
        await Repository.CreateOrder(order);
        await Repository.SaveChanges();

        await DomainLogger.LogInformation(new DomainLog(string.Format(CreateOrderMessages.PurchaseOrderCreatedTemplate, order.Id)));

        await OutputPort.Handle(order);
        if(order.OrderDetails.Count > 3)
            await DomainEventHub.Rise(
                new SpecialOrderCreatedEvent(order.Id, order.OrderDetails.Count));
    }
}

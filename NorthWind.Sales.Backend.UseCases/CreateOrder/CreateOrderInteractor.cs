namespace NorthWind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderInteractor(
    ICreateOrderOutputPort OutputPort,
    ICommandsRepository Repository,
    IModelValidatorHub<CreateOrderDto> ModelValidatorHub,
    IDomainEventHub<SpecialOrderCreatedEvent> DomainEventHub,
    IDomainLogger DomainLogger,
    IDomainTransaction DomainTransaction,
    IUserService UserService
    ) : ICreateOrderInputPort
{
    public async Task Handle(CreateOrderDto orderDto)
    {
        GuardUser.AgainstUnauthenticated(UserService);

        await GuardModel.AgainstNotValid(ModelValidatorHub, orderDto);

        await DomainLogger.LogInformation(new DomainLog(CreateOrderMessages.StartingPurchaseOrderCreation, UserService.UserName));

        OrderAgregate order = OrderAgregate.From(orderDto);

        try
        {
            DomainTransaction.BeginTransaction();

            await Repository.CreateOrder(order);
            await Repository.SaveChanges();

            await DomainLogger.LogInformation(new DomainLog(string.Format(CreateOrderMessages.PurchaseOrderCreatedTemplate, order.Id), UserService.UserName));

            await OutputPort.Handle(order);
            if (new SpecialOrderSpecification().IsSatisfiedBy(order))
            {
                await DomainEventHub.Rise(
                    new SpecialOrderCreatedEvent(order.Id, order.OrderDetails.Count));
            }

            DomainTransaction.CommitTransaction();
        }
        catch
        {
            DomainTransaction.RollbackTransaction();
            string information = string.Format(CreateOrderMessages.OrderCreationCancelledTemplate, order.Id);
            await DomainLogger.LogInformation(new DomainLog(information, UserService.UserName));
            throw;
        }

    }
}

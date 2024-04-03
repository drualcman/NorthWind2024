using NorthWind.Entities.Interfaces;

namespace NorthWind.Sales.Backend.UseCases.CreateOrder;
internal class SendEmailWhenSpecialOrderCreatedEventHandler(IMailService MailService) : IDomainEventHandler<SpecialOrderCreatedEvent>
{
    public Task Handle(SpecialOrderCreatedEvent createdOrder) =>
        MailService.SendMailToAdministrator(
            CreateOrderMessages.SendEmailsubject, 
            string.Format(CreateOrderMessages.SendEmailBodyTemplate, 
                createdOrder.OrderId, createdOrder.ProductsCount));
}

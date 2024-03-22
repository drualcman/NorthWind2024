namespace NorthWind.Events.Services;
internal class DomainEventHub<EventType>(IEnumerable<IDomainEventHandler<EventType>> EventHandlers) :
    IDomainEventHub<EventType> where EventType : IDomainEvent
{
    public async Task Rise(EventType eventTypeInstance)
    {
        foreach (IDomainEventHandler<EventType> handler in EventHandlers)
        {
             await handler.Handle(eventTypeInstance);
        }
    }
}

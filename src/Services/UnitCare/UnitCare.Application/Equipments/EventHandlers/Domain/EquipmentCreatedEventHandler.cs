namespace UnitCare.Application.Equipments.EventHandlers.Domain;


public class EquipmentCreatedEventHandler(ILogger<EquipmentCreatedEventHandler> logger)
    : INotificationHandler<EquipmentCreatedEvent>
{
    public Task Handle(EquipmentCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }
}
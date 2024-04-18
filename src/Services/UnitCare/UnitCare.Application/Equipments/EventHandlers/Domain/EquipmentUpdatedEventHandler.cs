namespace UnitCare.Application.Equipments.EventHandlers.Domain;


public class EquipmentUpdatedEventHandler(ILogger<EquipmentUpdatedEventHandler> logger)
    : INotificationHandler<EquipmentUpdatedEvent>
{
    public Task Handle(EquipmentUpdatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }
}
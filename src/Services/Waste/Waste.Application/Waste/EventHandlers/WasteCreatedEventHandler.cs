
namespace Waste.Application.Wastes.EventHandlers;

public class RoomCreatedEventHandler (ILogger<RoomCreatedEventHandler> logger)
    : INotificationHandler<WasteCreatedEvent>
{
    public Task Handle(WasteCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
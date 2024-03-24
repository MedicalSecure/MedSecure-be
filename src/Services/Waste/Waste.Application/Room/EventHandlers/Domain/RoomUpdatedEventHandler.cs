
namespace Waste.Application.Room.EventHandlers.Domain;

public class RoomUpdatedEventHandler(ILogger<RoomUpdatedEventHandler> logger)
    : INotificationHandler<RoomUpdatedEvent>
{
    public Task Handle(RoomUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
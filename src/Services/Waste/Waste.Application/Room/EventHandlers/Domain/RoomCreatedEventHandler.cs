
namespace Waste.Application.Room.EventHandlers.Domain;

public class RoomCreatedEventHandler(ILogger<RoomCreatedEventHandler> logger)
    : INotificationHandler<RoomCreatedEvent>
{
    public Task Handle(RoomCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}

namespace Waste.Application.Room.EventHandlers.Domain;

public class RoomUpdatedEventHandler(ILogger<RoomUpdatedEventHandler> logger)
    : INotificationHandler<RoomUpdatedEvent>
{
    public Task Handle(RoomUpdatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }

}
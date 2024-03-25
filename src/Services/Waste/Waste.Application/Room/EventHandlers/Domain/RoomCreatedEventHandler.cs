
namespace Waste.Application.Room.EventHandlers.Domain;

public class RoomCreatedEventHandler(ILogger<RoomCreatedEventHandler> logger)
    : INotificationHandler<RoomCreatedEvent>
{
    public Task Handle(RoomCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }

}
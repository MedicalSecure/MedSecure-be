
namespace Waste.Application.Waste.EventHandlers.Domain;

public class WasteUpdatedEventHandler(ILogger<WasteUpdatedEventHandler> logger)
    : INotificationHandler<WasteUpdatedEvent>
{
    public Task Handle(WasteUpdatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }

}
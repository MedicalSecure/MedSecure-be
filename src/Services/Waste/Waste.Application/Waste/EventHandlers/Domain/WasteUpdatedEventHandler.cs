
namespace Waste.Application.Waste.EventHandlers.Domain;

public class WasteUpdatedEventHandler(ILogger<WasteUpdatedEventHandler> logger)
    : INotificationHandler<WasteUpdatedEvent>
{
    public Task Handle(WasteUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
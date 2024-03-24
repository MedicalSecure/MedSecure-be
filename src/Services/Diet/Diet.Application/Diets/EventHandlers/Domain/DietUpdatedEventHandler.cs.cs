
namespace Diet.Application.Diets.EventHandlers.Domain;

public class DietUpdatedEventHandler(ILogger<DietUpdatedEventHandler> logger)
    : INotificationHandler<DietUpdatedEvent>
{
    public Task Handle(DietUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
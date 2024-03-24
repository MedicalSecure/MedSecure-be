
namespace Diet.Application.Diets.EventHandlers.Domain;

public class DietCreatedEventHandler(ILogger<DietCreatedEventHandler> logger)
    : INotificationHandler<DietCreatedEvent>
{
    public Task Handle(DietCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
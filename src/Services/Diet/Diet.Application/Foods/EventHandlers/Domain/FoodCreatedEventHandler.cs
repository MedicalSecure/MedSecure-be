
namespace Diet.Application.Foods.EventHandlers.Domain;

public class FoodCreatedEventHandler(ILogger<FoodCreatedEventHandler> logger)
    : INotificationHandler<FoodCreatedEvent>
{
    public Task Handle(FoodCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
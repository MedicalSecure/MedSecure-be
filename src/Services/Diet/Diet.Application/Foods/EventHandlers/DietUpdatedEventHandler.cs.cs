
namespace Diet.Application.Foods.EventHandlers;

public class FoodUpdatedEventHandler(ILogger<FoodUpdatedEventHandler> logger)
    : INotificationHandler<FoodUpdatedEvent>
{
    public Task Handle(FoodUpdatedEvent notification, CancellationToken cancellationToken)
{
    logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
    return Task.CompletedTask;
}
}
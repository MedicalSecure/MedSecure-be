
namespace Diet.Application.Foods.EventHandlers.Domain;

public class FoodUpdatedEventHandler(ILogger<FoodUpdatedEventHandler> logger)
    : INotificationHandler<FoodUpdatedEvent>
{
    public Task Handle(FoodUpdatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }
}
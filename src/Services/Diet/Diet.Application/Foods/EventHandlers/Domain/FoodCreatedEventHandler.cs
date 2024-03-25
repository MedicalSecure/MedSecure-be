
namespace Diet.Application.Foods.EventHandlers.Domain;

public class FoodCreatedEventHandler(ILogger<FoodCreatedEventHandler> logger)
    : INotificationHandler<FoodCreatedEvent>
{
    public Task Handle(FoodCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }
}
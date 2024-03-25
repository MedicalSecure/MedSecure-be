
namespace Diet.Application.Diets.EventHandlers.Domain;

public class DietUpdatedEventHandler(ILogger<DietUpdatedEventHandler> logger)
    : INotificationHandler<DietUpdatedEvent>
{
    public Task Handle(DietUpdatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }

}
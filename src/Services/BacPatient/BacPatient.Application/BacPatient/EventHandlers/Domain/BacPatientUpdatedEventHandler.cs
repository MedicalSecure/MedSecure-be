
namespace Diet.Application.Diets.EventHandlers.Domain;

public class BacPatientUpdatedEventHandler(ILogger<BacPatientUpdatedEventHandler> logger)
    : INotificationHandler<BPUpdatedEvent>
{
    public Task Handle(BPUpdatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }

}
namespace BacPatient.Application.BPModels.EventHandlers.Domain;

public class BacPatientEventHandler(ILogger<BacPatientEventHandler> logger)
    : INotificationHandler<BPCreatedEvent>
{
    public Task Handle(BPCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }

}
namespace Medication.Application.Dosages.EventHandlers.Domain;


public class DosageUpdatedEventHandler(ILogger<DosageUpdatedEventHandler> logger)
    : INotificationHandler<DosageUpdatedEvent>
{
    public Task Handle(DosageUpdatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }
}

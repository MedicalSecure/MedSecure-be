namespace Medication.Application.Dosages.EventHandlers.Domain;


public class DosageCreatedEventHandler(ILogger<DosageCreatedEventHandler> logger)
    : INotificationHandler<DosageCreatedEvent>
{
    public Task Handle(DosageCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }
}

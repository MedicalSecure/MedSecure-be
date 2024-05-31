namespace Medication.Application.Drugs.EventHandlers.Domain;


public class DrugCreatedEventHandler(ILogger<DrugCreatedEventHandler> logger)
    : INotificationHandler<DrugCreatedEvent>
{
    public Task Handle(DrugCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }
}

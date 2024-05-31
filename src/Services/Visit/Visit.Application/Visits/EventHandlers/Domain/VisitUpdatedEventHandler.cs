

namespace Visit.Application.Visits.EventHandlers.Domain;

public class VisitUpdatedEventHandler(ILogger<VisitUpdatedEventHandler> logger)
    : INotificationHandler<VisitUpdtedEvent>
{
    public Task Handle(VisitUpdtedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }

}
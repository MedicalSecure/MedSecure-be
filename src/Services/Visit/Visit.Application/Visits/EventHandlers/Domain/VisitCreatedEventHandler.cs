
namespace Visit.Application.Visits.EventHandlers.Domain;
public class VisitCreatedEventHandler(ILogger<VisitCreatedEventHandler> logger)
    : INotificationHandler<VisitCreatedEvent>
{
    public Task Handle(VisitCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }

}

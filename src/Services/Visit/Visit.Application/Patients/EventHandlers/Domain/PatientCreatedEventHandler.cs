
namespace Visit.Application.Patients.EventHandlers.Domain;
public class PatientCreatedEventHandler(ILogger<PatientCreatedEventHandler> logger)
    : INotificationHandler<PatientCreatedEvent>
{
    public Task Handle(PatientCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }

}
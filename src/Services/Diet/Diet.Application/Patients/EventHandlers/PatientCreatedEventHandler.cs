
namespace Diet.Application.Patients.EventHandlers;

public class PatientCreatedEventHandler(ILogger<PatientCreatedEventHandler> logger)
    : INotificationHandler<PatientCreatedEvent>
{
    public Task Handle(PatientCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
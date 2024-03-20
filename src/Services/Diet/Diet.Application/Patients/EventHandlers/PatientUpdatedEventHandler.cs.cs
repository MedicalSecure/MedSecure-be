
namespace Diet.Application.Patients.EventHandlers;

public class PatientUpdatedEventHandler(ILogger<PatientUpdatedEventHandler> logger)
    : INotificationHandler<PatientUpdatedEvent>
{
    public Task Handle(PatientUpdatedEvent notification, CancellationToken cancellationToken)
{
    logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
    return Task.CompletedTask;
}
}
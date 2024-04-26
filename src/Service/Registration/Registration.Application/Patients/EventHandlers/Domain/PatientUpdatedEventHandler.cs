using MediatR;
using Microsoft.Extensions.Logging;
using Registration.Domain.Events;


namespace Registration.Application.Patients.EventHandlers.Domain
{
    public class PatientUpdatedEventHandler(ILogger<PatientUpdatedEventHandler> logger)
      : INotificationHandler<PatientUpdatedEvent>
    {
        public Task Handle(PatientUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Log that the domain event is being handled
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            // Return a completed task since there is no further asynchronous work to be done
            return Task.CompletedTask;
        }

    }
}

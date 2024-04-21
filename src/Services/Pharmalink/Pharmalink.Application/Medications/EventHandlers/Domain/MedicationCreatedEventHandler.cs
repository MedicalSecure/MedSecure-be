using MediatR;
using Microsoft.Extensions.Logging;
using Pharmalink.Domain.Events;

namespace Pharmalink.Application.Medications.EventHandlers.Domain;
public class MedicationCreatedEventHandler(ILogger<MedicationCreatedEventHandler> logger)
    : INotificationHandler<MedicationCreatedEvent>
{
    public Task Handle(MedicationCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }
}

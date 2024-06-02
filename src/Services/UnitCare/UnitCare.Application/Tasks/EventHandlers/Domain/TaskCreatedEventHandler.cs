using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCare.Domain.Events;

namespace UnitCare.Application.Tasks.EventHandlers.Domain;

public class TaskCreatedEventHandler(ILogger<TaskCreatedEventHandler> logger)
    : INotificationHandler<TaskCreatedEvent>
{
    public System.Threading.Tasks.Task Handle(TaskCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return System.Threading.Tasks.Task.CompletedTask;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.UnitCares.EventHandlers.Domain;


public class UnitCareCreatedEventHandler(ILogger<UnitCareCreatedEventHandler> logger)
    : INotificationHandler<UnitCareCreatedEvent>
{
    public System.Threading.Tasks.Task Handle(UnitCareCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return System.Threading.Tasks.Task.CompletedTask;
    }

}

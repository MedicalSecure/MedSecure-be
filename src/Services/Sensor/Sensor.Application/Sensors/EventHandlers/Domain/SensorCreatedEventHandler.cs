using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Application.Sensors.EventHandlers.Domain;

public class SensorCreatedEventHandler (ILogger<SensorCreatedEventHandler> logger)
    : INotificationHandler<SensorCreatedEvent>
{
    public Task Handle(SensorCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Return a completed task since there is no further asynchronous work to be done
        return Task.CompletedTask;
    }
}

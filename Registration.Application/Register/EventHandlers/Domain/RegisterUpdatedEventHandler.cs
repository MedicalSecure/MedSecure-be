using MediatR;
using Microsoft.Extensions.Logging;
using Registration.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Register.EventHandlers.Domain
{
    public class RegisterUpdatedEventHandler
    (ILogger<RegisterUpdatedEventHandler> logger)
      : INotificationHandler<RegisterUpdatedEvent>
    {
        public Task Handle(RegisterUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Log that the domain event is being handled
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            // Return a completed task since there is no further asynchronous work to be done
            return Task.CompletedTask;
        }

    }
}

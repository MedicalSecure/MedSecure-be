using MediatR;
using Microsoft.Extensions.Logging;
using Registration.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.RiskFactors.EventHandlers.Domain
{
    public class RiskFactorUpdatedEventHandler
    (ILogger<RiskFactorUpdatedEventHandler> logger)
      : INotificationHandler<RiskFactorUpdatedEvent>
    {
        public Task Handle(RiskFactorUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Log that the domain event is being handled
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            // Return a completed task since there is no further asynchronous work to be done
            return Task.CompletedTask;
        }

    }
}

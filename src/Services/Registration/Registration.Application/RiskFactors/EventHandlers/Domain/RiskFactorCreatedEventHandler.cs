using MediatR;
using Microsoft.Extensions.Logging;
using Registration.Application.Registers.EventHandlers.Domain;
using Registration.Domain.Events;

namespace Registration.Application.RiskFactors.EventHandlers.Domain
{
    public class RiskFactorCreatedEventHandler(ILogger<RiskFactorCreatedEventHandler> logger)
        : INotificationHandler<RiskFactorCreatedEvent>
    {
        public Task Handle(RiskFactorCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Log that the domain event is being handled
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            // Return a completed task since there is no further asynchronous work to be done
            return Task.CompletedTask;
        }

    }

}


namespace Registration.Application.Registers.EventHandlers.Domain
{
    public class RegisterCreatedEventHandler
    (ILogger<RegisterCreatedEventHandler> logger)
        : INotificationHandler<RegisterCreatedEvent>
    {
        public Task Handle(RegisterCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Log that the domain event is being handled
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            // Return a completed task since there is no further asynchronous work to be done
            return Task.CompletedTask;
        }

    }
}
    
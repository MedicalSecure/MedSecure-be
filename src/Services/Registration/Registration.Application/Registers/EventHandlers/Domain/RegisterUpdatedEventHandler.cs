namespace Registration.Application.Registers.EventHandlers.Domain
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

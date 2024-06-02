using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Tests.EventHandlers.Domain
{
    public class TestCreatedEventHandler : INotificationHandler<TestCreatedEvent>
    {
        private readonly ILogger<TestCreatedEventHandler> _logger;

        public TestCreatedEventHandler(ILogger<TestCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TestCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Log that the domain event is being handled
            _logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            // Return a completed task since there is no further asynchronous work to be done
            return Task.CompletedTask;
        }
    }
}

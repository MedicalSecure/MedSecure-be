
namespace Waste.Application.Products.EventHandlers;

public class ProductUpdatedEventHandler(ILogger<ProductUpdatedEventHandler> logger)
    : INotificationHandler<ProductUpdatedEvent>
{
    public Task Handle(ProductUpdatedEvent notification, CancellationToken cancellationToken)
{
    logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
    return Task.CompletedTask;
}
}
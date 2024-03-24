
using Waste.Application.Room.EventHandlers.Domain;

namespace Waste.Application.Waste.EventHandlers.Domain;

public class WasteCreatedEventHandler(ILogger<RoomCreatedEventHandler> logger)
    : INotificationHandler<WasteCreatedEvent>
{
    public Task Handle(WasteCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
        //if (await featureManager.IsEnabledAsync("WasteFullfilment"))
        //{
        //    var wasteCreatedIntegrationEvent = notification.waste.ToWasteDto();
        //    await publishEndpoint.Publish(wasteCreatedIntegrationEvent, cancellationToken);
        //}
    }
}
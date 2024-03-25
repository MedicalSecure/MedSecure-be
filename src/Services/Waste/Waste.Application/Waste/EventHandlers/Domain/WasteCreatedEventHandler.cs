


namespace Waste.Application.Waste.EventHandlers.Domain;

public class WasteCreatedEventHandler(ILogger<WasteCreatedEventHandler> logger, IFeatureManager featureManager, IPublishEndpoint publishEndpoint)
    : INotificationHandler<WasteCreatedEvent>
{
    public async Task Handle(WasteCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Log that the domain event is being handled
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // Check if the feature for using message broker is enabled
        if (await featureManager.IsEnabledAsync("DietPlanSharedFulfillment"))
        {
            // Convert waste to DTO
            var wasteCreatedIntegrationEvent = notification.Waste.ToWasteDto();

            // Publish the integration event to the message broker
            await publishEndpoint.Publish(wasteCreatedIntegrationEvent, cancellationToken);
        }

        // The task is completed; no further action needed
        // return Task.CompletedTask;
    }
}
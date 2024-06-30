
namespace Waste.Application.Waste.EventHandlers.Integration;

public class DietPlanSharedEventHandler
(ISender sender, ILogger<DietPlanSharedEventHandler> logger)
: IConsumer<DietPlanSharedEvent>
{
    public async Task Consume(ConsumeContext<DietPlanSharedEvent> context)
    {
        // TODO: Create new Waste and start Waste fullfillment process
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateWasteCommand(context.Message);
        await sender.Send(command);
    }

    private static CreateWasteCommand MapToCreateWasteCommand(DietPlanSharedEvent message)
    {
        // Create addresses from incoming event data
        var pickupLocationDto = new AddressDto("123 Clinic St", "Clinicville", "State", "12345", "Country", "123-456-7890", "clinic@example.com");
        var dropOffLocationDto = new AddressDto("456 Municipal Ave", "Municipal City", "State", "54321", "Country", "987-654-3210", "municipal@example.com");

        var wasteItems = message.Meals.Select(meal => new WasteItemDto(Guid.NewGuid(), Guid.NewGuid(), meal.Id, 1, 0)).ToList();

        // Assuming WasteStatus and WasteColor are enums
        var status = WasteStatus.Pending;
        var color = WasteColor.Black;
        // message.PatientId
        var wasteDto = new WasteDto(
            Id: Guid.NewGuid(),
            RoomId: Guid.NewGuid(),
            PickupLocation: pickupLocationDto,
            DropOffLocation: dropOffLocationDto,
            Status: status,
            Color: color,
            WasteItems: wasteItems
        );

        return new CreateWasteCommand(wasteDto);
    }
}
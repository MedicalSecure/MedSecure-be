
namespace Waste.Application.Wastes.Commands.UpdateWaste;

public class UpdateWasteHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateWasteCommand, UpdateWasteResult>
{
    public async Task<UpdateWasteResult> Handle(UpdateWasteCommand command, CancellationToken cancellationToken)
    {
        // Update Waste entity from command object
        // save to database
        // return result
        var wasteId = WasteId.Of(command.Waste.Id);
        var waste = await dbContext.Wastes.FindAsync([wasteId], cancellationToken);

        if (waste == null)
        {
            throw new WasteNotFoundException(command.Waste.Id);
        }

        UpdateWasteWithNewValues(waste, command.Waste);

        dbContext.Wastes.Update(waste);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateWasteResult(true);
    }
    private static void UpdateWasteWithNewValues(Domain.Models.Waste waste, WasteDto wasteDto)
    {
        var pickupLocation = Address.Of(wasteDto.PickupLocation.Street, wasteDto.PickupLocation.City, wasteDto.PickupLocation.State, wasteDto.PickupLocation.ZipCode, wasteDto.PickupLocation.Country, wasteDto.PickupLocation.Phone, wasteDto.PickupLocation.Email);
        var dropOffLocation = Address.Of(wasteDto.DropOffLocation.Street, wasteDto.DropOffLocation.City, wasteDto.DropOffLocation.State, wasteDto.DropOffLocation.ZipCode, wasteDto.DropOffLocation.Country, wasteDto.DropOffLocation.Phone, wasteDto.DropOffLocation.Email);

        waste.Update(RoomId.Of(wasteDto.RoomId), pickupLocation, dropOffLocation, wasteDto.Status, wasteDto.Color);
    }
}
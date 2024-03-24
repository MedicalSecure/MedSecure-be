
namespace Waste.Application.Waste.Commands.CreateWaste;

public class CreateWasteHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateWasteCommand, CreateWasteResult>
{
    public async Task<CreateWasteResult> Handle(CreateWasteCommand command, CancellationToken cancellationToken)
    {
        // create Waste entity from command object
        // save to database
        // return result
        var waste = CreateNewWaste(command.Waste);

        dbContext.Wastes.Add(waste);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateWasteResult(waste.Id.Value);
    }

    private static Domain.Models.Waste CreateNewWaste(WasteDto wasteDto)
    {
        var newWaste = Domain.Models.Waste.Create(
         id: WasteId.Of(Guid.NewGuid()),
         roomId: RoomId.Of(wasteDto.RoomId),
         pickupLocation: new Address(wasteDto.PickupLocation.Street,
                                     wasteDto.PickupLocation.City,
                                     wasteDto.PickupLocation.State,
                                     wasteDto.PickupLocation.ZipCode,
                                     wasteDto.PickupLocation.Country,
                                     wasteDto.PickupLocation.Phone,
                                     wasteDto.PickupLocation.Email),
         dropOffLocation: new Address(wasteDto.DropOffLocation.Street,
                                      wasteDto.DropOffLocation.City,
                                      wasteDto.DropOffLocation.State,
                                      wasteDto.DropOffLocation.ZipCode,
                                      wasteDto.DropOffLocation.Country,
                                      wasteDto.DropOffLocation.Phone,
                                      wasteDto.DropOffLocation.Email),
         status: wasteDto.Status,
         color: wasteDto.Color
     );

        foreach (var waste in wasteDto.WasteItems)
        {
           newWaste.AddItem(WasteId.Of(waste.Id), ProductId.Of(waste.ProductId), waste.Quantity, waste.Weight);
        }

        return newWaste;
    }
}
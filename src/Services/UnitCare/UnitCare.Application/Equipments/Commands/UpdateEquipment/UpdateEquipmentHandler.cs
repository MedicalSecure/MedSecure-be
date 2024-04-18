namespace UnitCare.Application.Equipments.Commands.UpdateEquipment;


public class UpdateEquipmentHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateEquipmentCommand, UpdateEquipmentResult>
{
    public async Task<UpdateEquipmentResult> Handle(UpdateEquipmentCommand command, CancellationToken cancellationToken)
    {
        // Update Equipment entity from command object
        // save to database
        // return result
        var equipmentId = EquipmentId.Of(command.Equipment.Id);
        var equipment = await dbContext.Equipments.FindAsync([equipmentId], cancellationToken);

        if (equipment == null)
        {
            throw new EquipmentNotFoundException(command.Equipment.Id);
        }

        UpdateEquipmentWithNewValues(equipment, command.Equipment);

        dbContext.Equipments.Update(equipment);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateEquipmentResult(true);
    }

    private static void UpdateEquipmentWithNewValues(Equipment equipment, EquipmentDto equipmentDto)
    {
        equipment.Update(equipmentDto.Name, RoomId.Of(equipmentDto.RoomId), equipmentDto.Reference);
    }
}

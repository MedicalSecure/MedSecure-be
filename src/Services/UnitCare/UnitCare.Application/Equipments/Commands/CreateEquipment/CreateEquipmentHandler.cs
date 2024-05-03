namespace UnitCare.Application.Equipments.Commands.CreateEquipment;

public class CreateEquipmentHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateEquipmentCommand, CreateEquipmentResult>
{
    public async Task<CreateEquipmentResult> Handle(CreateEquipmentCommand command, CancellationToken cancellationToken)
    {
        // create Equipment entity from command object
        // save to database
        // return result
        var equipment = CreateNewEquipment(command.Equipment);

        dbContext.Equipments.Add(equipment);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateEquipmentResult(equipment.Id.Value);
    }

    private static Equipment CreateNewEquipment(EquipmentDto equipmentDto)
    {
        //EquipmentId id, string name, string reference
        var newEquipment = Equipment.Create(
            id: EquipmentId.Of(Guid.NewGuid()),
            roomId: RoomId.Of(equipmentDto.RoomId),
            name: equipmentDto.Name,
            reference: equipmentDto.Reference,
            eqStatus: equipmentDto.EqStatus

            );

        return newEquipment;
    }
}


using UnitCare.Domain.ValueObjects;

namespace UnitCare.Application.UnitCares.Commands.CreateUnitCare;

public class CreateUnitCareHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<CreateUnitCareCommand, CreateUnitCareResult>
{
    public async Task<CreateUnitCareResult> Handle(CreateUnitCareCommand command, CancellationToken cancellationToken)
    {
        // create UnitCare entity from command object
        var unitCare = CreateNewUnitCare(command.UnitCare);

        // save to database
        dbContext.UnitCares.Add(unitCare);
        await dbContext.SaveChangesAsync(cancellationToken);

        // Check if the feature for using message broker is enabled
        if (await featureManager.IsEnabledAsync("UnitCarePlanSharedFulfillment"))
        {
            // Adapt the command.UnitCare object to a DietPlanSharedEvent and publish it
            var eventMessage = command.UnitCare.Adapt<DietPlanSharedEvent>();
            await publishEndpoint.Publish(eventMessage, cancellationToken);
        }

        // return result containing the ID of the created unitCare
        return new CreateUnitCareResult(unitCare.Id.Value);
    }

    private static Domain.Models.UnitCare CreateNewUnitCare(UnitCareDto unitCareDto)
    {
        var newUnitCare = Domain.Models.UnitCare.Create(
            id: UnitCareId.Of(Guid.NewGuid()),
            title: unitCareDto.Title,
            description: unitCareDto.Description,
            type: unitCareDto.Type
            );

        foreach (var room in unitCareDto.Rooms)
        {
            var newRoom = Room.Create(RoomId.Of(room.Id), UnitCareId.Of(room.UnitCareId), room.RoomNumber, room.Status);

            foreach (var equipment in room.Equipments)
            {
                var newEquipment= Equipment.Create(EquipmentId.Of(equipment.Id), RoomId.Of(equipment.RoomId), equipment.Name, equipment.Reference, equipment.EqStatus);

                newRoom.AddEquipment(newEquipment);



            }

            newUnitCare.AddRoom(newRoom);



        }

        foreach (var personnel in unitCareDto.Personnels)
        {
            var newPersonnel = Personnel.Create(PersonnelId.Of(personnel.Id), UnitCareId.Of(personnel.UnitCareId), personnel.Name, personnel.Shift, personnel.Gender);
            newUnitCare.AddPersonnel(newPersonnel);

        }

        return newUnitCare;
    }
}

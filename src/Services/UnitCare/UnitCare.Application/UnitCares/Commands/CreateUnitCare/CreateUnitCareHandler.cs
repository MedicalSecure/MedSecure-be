

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

        Guid createdBy = Guid.NewGuid();
        var newActivity = Domain.Models.Activity.Create(createdBy, $"Created new {nameof(unitCare)}", "Ranim.M");
        dbContext.Activities.Add(newActivity);
        try
        {

        await dbContext.SaveChangesAsync(cancellationToken);

        }
        catch (Exception x)
        {

            throw x;
        }

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
            type: unitCareDto.Type,
            unitStatus: unitCareDto.UnitStatus
            );

        foreach (var room in unitCareDto.Rooms)
        {
            var newRoom = Room.Create(RoomId.Of(Guid.NewGuid()), newUnitCare.Id, room.RoomNumber, room.Status);

            foreach (var equipment in room.Equipments)
            {
                var newEquipment= Equipment.Create(EquipmentId.Of(Guid.NewGuid()), newRoom.Id, equipment.Name, equipment.Reference, equipment.EqStatus, equipment.EqType);

                newRoom.AddEquipment(newEquipment);



            }

            newUnitCare.AddRoom(newRoom);



        }

        foreach (var personnel in unitCareDto.Personnels)
        {
            var newPersonnel = Personnel.Create(PersonnelId.Of(Guid.NewGuid()), newUnitCare.Id, personnel.Name, personnel.Shift, personnel.Gender);
            newUnitCare.AddPersonnel(newPersonnel);

        }

        return newUnitCare;
    }
}

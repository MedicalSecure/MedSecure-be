using BacPatient.Application.BPModels.Commands.CreateBacPatient;

namespace BacPatient.Application.BacPatient.Commands.CreateBPModel;

public class CreateBacPatientHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<CreateBacPatientCommand, CreateBacPatientResult>
{
    public async Task<CreateBacPatientResult> Handle(CreateBacPatientCommand command, CancellationToken cancellationToken)
    {
        var bacPatients = CreateNewBP(command.BacPatients);

        dbContext.BacPatients.Add(bacPatients);
        await dbContext.SaveChangesAsync(cancellationToken);

        if (await featureManager.IsEnabledAsync("DietPlanSharedFulfillment"))
        {
            var eventMessage = command.BacPatients.Adapt<BacPatientSharedEvent>();
            await publishEndpoint.Publish(eventMessage, cancellationToken);
        }

        return new CreateBacPatientResult(bacPatients.Id);
    }

    private static Domain.Models.BacPatient CreateNewBP(BacPatientDto bacPatients)
    {
        var newBPModel = Domain.Models.BacPatient.Create(
            Id: new Guid(),
                Register: bacPatients.Register,
                UnitCare: bacPatients.UnitCare,
                Bed: bacPatients.Bed,
                NurseId: bacPatients.NurseId,
                Served: bacPatients.Served,
                ToServe: bacPatients.ToServe,
                Status: bacPatients.Status
        ); 

        foreach (var roomDto in bacPatients.UnitCare.Rooms)
        {
            var newRoomModel = Domain.Models.Room.Create(
                id:RoomId.Of( roomDto.Id),
                unitCareId: newBPModel.UnitCare.Id,
                roomNumber: roomDto.RoomNumber,
                status: roomDto.Status
            );

            foreach (var equipmentDto in roomDto.Equipments)
            {
                var newEquipmentModel = Domain.Models.Equipment.Create(
                    id: EquipmentId.Of( equipmentDto.Id),
                    roomId: newRoomModel.Id,
                    name: equipmentDto.Name,
                    reference: equipmentDto.Reference
                );

                newRoomModel.AddEquipment(newEquipmentModel);
            }

            newBPModel.UnitCare.AddRoom(newRoomModel);
        }

        foreach (var personnelDto in bacPatients.UnitCare.Personnels)
        {
            var newPersonnelModel = Domain.Models.Personnel.Create(
                id: PersonnelId.Of(personnelDto.Id) ,
                unitCareId: newBPModel.UnitCare.Id,
                name: personnelDto.Name,
                shift: personnelDto.Shift,
                gender: personnelDto.Gender
            );

            newBPModel.UnitCare.AddPersonnel(newPersonnelModel);
        }

        return newBPModel;
    }
}
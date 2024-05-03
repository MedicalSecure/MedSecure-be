using BacPatient.Application.BPModels.Commands.CreateBacPatient;
using BacPatient.Application.DTOs;
using BacPatient.Domain.Models.RegisterRoot;

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
                Register: Register.Create(
                      id: bacPatients.Register.Id,
                     patient: Patient.Create(
                    bacPatients.Register.Patient.firstName,
                     bacPatients.Register.Patient.lastName,
                    bacPatients.Register.Patient.dateOfbirth,
                     bacPatients.Register.Patient.cin,
                     bacPatients.Register.Patient.cnam,
                    bacPatients.Register.Patient.gender,
                     bacPatients.Register.Patient.height,
                    bacPatients.Register.Patient.weight,
                     bacPatients.Register.Patient.email,
                     bacPatients.Register.Patient.address1,
                     bacPatients.Register.Patient.address2,
                     bacPatients.Register.Patient.country,
                     bacPatients.Register.Patient.state,
                    bacPatients.Register.Patient.familyStatus,
                     bacPatients.Register.Patient.children

                    ),
        familyHistory: bacPatients.Register.FamilyMedicalHistory,
                personalHistory: bacPatients.Register.PersonalMedicalHistory,
                disease: bacPatients.Register.Diseases,
                allergy: bacPatients.Register.Allergies,
                test: bacPatients.Register.Test,
                history: bacPatients.Register.History,
        prescriptions: bacPatients.Register.Prescriptions.ToList().Select(pres => pres.ToPrescriptionEntity()).ToList()),
              
                Bed: bacPatients.Bed,
                NurseId: bacPatients.NurseId,
                Served: bacPatients.Served,
                ToServe: bacPatients.ToServe,
                Status: bacPatients.Status
        )  ; 
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
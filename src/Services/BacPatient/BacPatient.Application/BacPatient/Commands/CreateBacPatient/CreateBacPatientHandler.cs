using BacPatient.Application.BPModels.Commands.CreateBacPatient;
using BacPatient.Application.Extensions.SimpleBacPatientExtension;


namespace BacPatient.Application.BacPatient.Commands.CreateBPModel;

public class CreateBacPatientHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<CreateBacPatientCommand, CreateBacPatientResult>
{
    public async Task<CreateBacPatientResult> Handle(CreateBacPatientCommand command, CancellationToken cancellationToken)
    {
        var bacPatients = CreateNewBP(command.BacPatients);

        dbContext.BacPatients.Add(bacPatients);
        await dbContext.SaveChangesAsync(cancellationToken);

        if (await featureManager.IsEnabledAsync("BacPatientSharedFulfillment"))
        {
            var eventMessage = command.BacPatients.Adapt<BacPatientSharedEvent>();
            await publishEndpoint.Publish(eventMessage, cancellationToken);
        }

        return new CreateBacPatientResult(bacPatients.Id.Value);
    }
    private static Domain.Models.BacPatient CreateNewBP(BacPatientDto bacPatients)
    {
        var newBPModel = Domain.Models.BacPatient.Create(
            Id: BacPatienId.Of(Guid.NewGuid()),
            Prescription: Prescription.Create(
                Register: Register.Create(
                    id: bacPatients.Prescription.Register.Id,
                     patient: Patient.Create(
                    bacPatients.Prescription.Register.Patient.FirstName,
                    bacPatients.Prescription.Register.Patient.LastName,
                    bacPatients.Prescription.Register.Patient.DateOfbirth)

                     ),
                UnitCare: UnitCare.Create(
                                            id : UnitCareId.Of(bacPatients.Prescription.UnitCare.Id),
                                            title: bacPatients.Prescription.UnitCare.Title,
                                            description: bacPatients.Prescription.UnitCare.Description
                ),
                CreatedAt: bacPatients.Prescription.CreatedAt
                ),

                Bed: bacPatients.Bed,
                NurseId: bacPatients.NurseId,
                Served: bacPatients.Served,
                ToServe: bacPatients.ToServe,
                Status: bacPatients.Status,
                Room: Room.Create(id:RoomId.Of( bacPatients.Room.Id),
                                    roomNumber : bacPatients.Room.RoomNumber ,
                                    status : bacPatients.Room.Status
                )
        ); ;
        foreach (var posology in bacPatients.Prescription.Posologies)
        {
            var newPos = Posology.Create(PrescriptionId.Of(posology.PrescriptionId), posology.Medication.ToSimpleMedicineEntity(), posology.StartDate, posology.EndDate, posology.IsPermanent);
            newBPModel.Prescription.addPosology(newPos); 
            foreach (var comment in posology.Comments)
            {
                var newComment = Comment.Create(PosologyId.Of(comment.PosologyId), comment.Label, comment.Content);
                newPos.AddComment(newComment); 
            }
            foreach (var dispense in posology.Dispenses)
            {
                var newDispense = Dispense.Create( PosologyId.Of(dispense.PosologyId), dispense.Hour, dispense.QuantityBE, dispense.QuantityAE);
                newPos.AddDispense(newDispense); 
            }
        }
                return newBPModel;
        }
    }

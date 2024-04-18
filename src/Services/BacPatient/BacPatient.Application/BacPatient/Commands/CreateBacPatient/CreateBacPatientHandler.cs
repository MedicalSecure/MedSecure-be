using BacPatient.Application.BPModels.Commands.CreateBacPatient;
using MediatR;
using Microsoft.FeatureManagement;

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
            var eventMessage = command.BacPatients.Adapt<BPModelPlanSharedEvent>();
            await publishEndpoint.Publish(eventMessage, cancellationToken);
        }

        return new CreateBacPatientResult(bacPatients.Id.Value);
    }

    private static Domain.Models.BacPatient CreateNewBP(BacPatientDto bacPatients)
    {
      
        var newBPModel = Domain.Models.BacPatient.Create(
            Id: BacPatienId.Of(Guid.NewGuid()),
            PatientId: PatientId.Of(bacPatients.PatientId),
            RoomId: RoomId.Of(bacPatients.RoomId) , 
            UnitCareId: UnitCareId.Of(bacPatients.UnitCareId),
            Bed: bacPatients.Bed,
            ServingDate : bacPatients.ServingDate ,
            Served: bacPatients.Served ,
            ToServe: bacPatients.ToServe ,
            Status: bacPatients.Status
            );
        foreach (var medicine in bacPatients.Medicines)
        {
            if (medicine != null)
            {
                var newMed = Medicine.Create(
                    MedicineId.Of(medicine.Id),
                    medicine.Name,
                    medicine.Form,
                    medicine.Dose,
                    medicine.Unit,
                    medicine.DateExp,
                    medicine.Stock,
                    medicine.Note
                );

                foreach (var pos in medicine.Posology)
                {
                    if (pos != null)
                    {
                        var newPos = Posology.Create(
                            PoslogyId.Of(pos.Id),
                            pos.StartDate,
                            pos.EndDate,
                            pos.QuantityBE,
                            pos.QuantityAE,
                            pos.IsPermanent,
                            pos.Hours
                        );
                        newMed.AddPosology(newPos);
                    }
                }
                newBPModel.AddMedicne(newMed);
            }
        }

        return newBPModel;

    }
}
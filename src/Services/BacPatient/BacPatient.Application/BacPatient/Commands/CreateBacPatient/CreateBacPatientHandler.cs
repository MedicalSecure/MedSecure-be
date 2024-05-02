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
            Id:new Guid(),
            Patient:Patient.Create(
          id: bacPatients.Patient.Id,
                patientName: bacPatients.Patient.PatientName,
                dateOfbirth: bacPatients.Patient.DateOfBirth.Date,
                gender: bacPatients.Patient.Gender,
                height: bacPatients.Patient.Height,
                weight: bacPatients.Patient.Weight,
                register: bacPatients.Patient.Register,
                riskFactor: bacPatients.Patient.RiskFactor,
                disease: bacPatients.Patient.Disease),
            Room: Room.Create(
                id: RoomId.Of(bacPatients.Room.Id) ,
                number:bacPatients.Room.Number,
                status:bacPatients.Room.Status,
                beds: bacPatients.Room.Beds
                )
            , 
            UnitCare:UnitCare.Create(
                Id: UnitCareId.Of(bacPatients.UnitCare.Id),
                Title:bacPatients.UnitCare.Title,
                Type:bacPatients.UnitCare.Type,
                Description:bacPatients.UnitCare.Description,
                Status:bacPatients.UnitCare.Status
                )
            ,
            NurseId : bacPatients.NurseId , 
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
                var newMed = Medication.Create(
                   id: medicine.Id,
                name: medicine.Name,
                dosage: medicine.Dosage,
                form: medicine.Form,
                code: medicine.Code,
                unit: medicine.Unit,
                description: medicine.Description,
                expiredAt: medicine.ExpiredAt,
                stock: medicine.Stock,
                alertStock: medicine.AlertStock,
                avrgStock: medicine.AvrgStock,
                minStock: medicine.MinStock,
                safetyStock: medicine.SafetyStock,
                reservedStock: medicine.ReservedStock,
                price: medicine.Price 

                );

            
                newBPModel.AddMedicne(newMed);
            }
        }

        return newBPModel;

    }
}
using BacPatient.Application.BPModels.Commands.CreateBacPatient;
using BacPatient.Application.Dtos;
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
            Prescription : Prescription.Create(
                Register: Register.Create(
                     patient: Patient.Create(
                    bacPatients.Prescription.Register.Patient.FirstName ,
                    bacPatients.Prescription.Register.Patient.LastName,
                    bacPatients.Prescription.Register.Patient.DateOfbirth),
                     prescriptions: new List<Prescription>()

                     )),

                Bed: bacPatients.Bed,
                NurseId: bacPatients.NurseId,
                Served: bacPatients.Served,
                ToServe: bacPatients.ToServe,
                Status: bacPatients.Status
        );

            var pres = new Prescription();

            foreach (var pos in pres.Posology)
            {
                var posology = Posology.Create(
                    prescriptionId : pres.Id ,
                medication : pos.Medication , 
                startDate : pos.StartDate ,
                endDate:pos.EndDate ,
                isPermanent : pos.IsPermanent ) ;

                pres.addPosology(pos);
            }



        return newBPModel;
        }
    }

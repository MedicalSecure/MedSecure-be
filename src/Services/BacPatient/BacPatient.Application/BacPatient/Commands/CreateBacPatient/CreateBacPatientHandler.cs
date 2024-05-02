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
            prescription: PrescriptionEntity.Create(

      patient: Patient.Create(
                firstName: bacPatients.Prescription.Patient.firstName,
                lastName: bacPatients.Prescription.Patient.lastName,
                dateOfbirth: bacPatients.Prescription.Patient.dateOfbirth,
                cin: bacPatients.Prescription.Patient.cin,
                cnam: bacPatients.Prescription.Patient.cnam,
                gender: bacPatients.Prescription.Patient.gender,
                height: bacPatients.Prescription.Patient.height,
                weight: bacPatients.Prescription.Patient.weight,
                email: bacPatients.Prescription.Patient.email,
                address1: bacPatients.Prescription.Patient.address1,
                address2: bacPatients.Prescription.Patient.address2,
                country: bacPatients.Prescription.Patient.country,
                state: bacPatients.Prescription.Patient.state,
                familyStatus: bacPatients.Prescription.Patient.familyStatus,
                children: bacPatients.Prescription.Patient.children
                ),
      doctor: Doctor.Create(
          firstName: bacPatients.Prescription.Doctor.FirstName , 
          lastName : bacPatients.Prescription.Doctor.LastName ,
          speciality: bacPatients.Prescription.Doctor.Specialty ,
          dateOfBirth : bacPatients.Prescription.Doctor.DateOfBirth

          )





        ),

    Room: Room.Create(
            id : bacPatients.Room.id , 
                number: bacPatients.Room.Number,
                status: bacPatients.Room.Status,
                beds: bacPatients.Room.Beds
                )


            ,
            NurseId: bacPatients.NurseId,
            Bed: bacPatients.Bed,
            Served: bacPatients.Served,
            ToServe: bacPatients.ToServe,
            Status: bacPatients.Status
            ) ;

        return newBPModel;

    }
}
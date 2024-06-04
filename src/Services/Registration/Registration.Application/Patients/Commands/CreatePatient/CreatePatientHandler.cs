using Registration.Application.Dtos;

namespace Registration.Application.Patients.Commands.CreatePatient
{
    public class CreatePatientHandler(IApplicationDbContext dbContext) : ICommandHandler<CreatePatientCommand, CreatePatientResult>
    {
        public async Task<CreatePatientResult> Handle(CreatePatientCommand command, CancellationToken cancellationToken)
        {
            // create Patient entity from command object
            // save to database
            // return result
            var patient = CreateNewPatient(command.Patient);

            dbContext.Patients.Add(patient);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreatePatientResult(patient.Id.Value);
        }

        public static Patient CreateNewPatient(PatientDto patientDto)
        {
            var newPatient = Patient.Create(
            id: PatientId.Of(Guid.NewGuid()),
                    firstName: patientDto.FirstName,
                    lastName: patientDto.LastName,
                    dateOfBirth: patientDto.DateOfBirth,
                    identity: patientDto.Identity,
                    gender: patientDto.Gender,
                    addressIsRegisterations: patientDto.AddressIsRegistrations ?? true,
                    saveForNextTime: patientDto.SaveForNextTime ?? true,
                    cnam: patientDto.CNAM,
                    assurance: patientDto.Assurance,
                    height: patientDto.Height,
                    weight: patientDto.Weight,
                    email: patientDto.Email,
                    address1: patientDto.Address1,
                    address2: patientDto.Address2,
                    country: patientDto.Country ?? Country.TN, // Assuming default value for Country is TN
                    state: patientDto.State,
                    zipCode: patientDto.ZipCode,
                    familyStatus: patientDto.FamilyStatus,
                    children: patientDto.Children,
                    activityStatus: patientDto.ActivityStatus 
            );

            return newPatient;
        }
    }
}
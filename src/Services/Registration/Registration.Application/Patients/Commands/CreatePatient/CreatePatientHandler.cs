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

        private static Patient CreateNewPatient(PatientDto patientDto)
        {
            var newPatient = Patient.Create(
                id: PatientId.Of(Guid.NewGuid()),
                firstName: patientDto.FirstName ?? string.Empty, // Default value if FirstName is null
                lastName: patientDto.LastName ?? string.Empty, // Default value if LastName is null
                dateOfBirth: patientDto.DateOfBirth,
                identity: patientDto.Identity ?? string.Empty, // Default value if Identity is null
                cnam: patientDto.CNAM ?? 0, // Default value if CNAM is null
                assurance: patientDto.Assurance,
                gender: patientDto.Gender ?? Gender.Male,
                height: patientDto.Height ?? 0, // Default value if Height is null
                weight: patientDto.Weight ?? 0, // Default value if Weight is null
                addressIsRegisterations: patientDto.AddressIsRegistrations,
                saveForNextTime: patientDto.SaveForNextTime,
                email: patientDto.Email,
                address1: patientDto.Address1,
                address2: patientDto.Address2,
                country: patientDto.Country,
                state: patientDto.State,
                zipCode: patientDto.ZipCode ?? 0, // Default value if ZipCode is null
                familyStatus: patientDto.FamilyStatus,
                children: patientDto.Children
            );

            return newPatient;
        }

    }
}

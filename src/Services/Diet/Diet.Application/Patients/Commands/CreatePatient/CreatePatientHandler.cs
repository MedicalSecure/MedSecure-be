
namespace Diet.Application.Patients.Commands.CreatePatient;

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
            firstName: patientDto.FirstName,
            lastName: patientDto.LastName,
            dateOfBirth: patientDto.DateOfBirth,
            gender: patientDto.Gender);

        return newPatient;
    }
}
using BuildingBlocks.CQRS;
using Registration.Application.Data;
using Registration.Application.Dtos;
using Registration.Domain.Models;
using Registration.Domain.ValueObjects;


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
                patientName: patientDto.patientName,
                dateOfbirth: patientDto.dateOfbirth,
                gender: patientDto.gender,
                height: patientDto.height,
                weight: patientDto.weight,
                register: patientDto.register,
                riskFactor: patientDto.riskFactor,
                disease: patientDto.disease
                );

            return newPatient;
        }
    }
}

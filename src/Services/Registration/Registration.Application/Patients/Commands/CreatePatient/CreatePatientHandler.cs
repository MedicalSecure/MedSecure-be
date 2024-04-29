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
                Id: PatientId.Of(Guid.NewGuid()),
                firstName: patientDto.firstName,
                lastName: patientDto.lastName,
                dateOfbirth: patientDto.dateOfbirth,
                cin:patientDto.cin,
                cnam:patientDto.cnam,
                gender: patientDto.gender,
                height: patientDto.height,
                weight: patientDto.weight,
                email:patientDto.email,
                address1:patientDto.address1,
                address2:patientDto.address2,
                country:patientDto.country,
                state:patientDto.state,
                familyStatus:patientDto.familyStatus,
                children:patientDto.children
                );

            return newPatient;
        }
    }
}

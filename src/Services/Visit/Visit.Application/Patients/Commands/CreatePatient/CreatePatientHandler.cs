using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Application.Patients.Commands.CreatePatient;
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
        if (patientDto == null)
        {
            throw new ArgumentNullException(nameof(patientDto), "PatientDto cannot be null");
        }

        var newPatient = Patient.Create(
            id: PatientId.Of(Guid.NewGuid()),
            firstName: patientDto.FirstName,
            lastName: patientDto.LastName,
            dateOfbirth: patientDto.DateOfBirth,
            cin: patientDto.CIN,
            cnam: patientDto.CNAM,
            gender: patientDto.Gender,
            height: patientDto.Height,
            weight: patientDto.Weight,
            email: patientDto.Email,
            address1:patientDto.Address1,
            address2: patientDto.Address2,
            country:patientDto.Country,
            state: patientDto.State,
            familyStatus: patientDto.FamilyStatus,
            children: patientDto.Children
            );

        return newPatient;
    }
}
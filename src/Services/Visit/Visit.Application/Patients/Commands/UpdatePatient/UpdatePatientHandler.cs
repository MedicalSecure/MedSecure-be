using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Application.Patients.Commands.UpdatePatient;
public class UpdatePatientHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdatePatientCommand, UpdatePatientResult>
{
    public async Task<UpdatePatientResult> Handle(UpdatePatientCommand command, CancellationToken cancellationToken)
    {
        // Update Patient entity from command object
        // save to database
        // return result

        //errur

        var patientId = PatientId.Of(command.Patient.Id);
        var patient = await dbContext.Patients.FindAsync([patientId], cancellationToken);

        if (patient == null)
        {
            throw new PatientNotFoundException(command.Patient.Id);
        }

        UpdatePatientWithNewValues(patient, command.Patient);

        dbContext.Patients.Update(patient);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdatePatientResult(true);
    }

    private static void UpdatePatientWithNewValues(Patient patient, PatientDto patientDto)
    {
        patient.Update(patientDto.FirstName, patientDto.LastName, patientDto.DateOfBirth, patientDto.Gender);
    }
}
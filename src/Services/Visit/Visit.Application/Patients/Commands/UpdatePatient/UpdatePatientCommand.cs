using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Application.Patients.Commands.UpdatePatient;
public record UpdatePatientCommand(PatientDto Patient) : ICommand<UpdatePatientResult>;

public record UpdatePatientResult(bool IsSuccess);

public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
{
    public UpdatePatientCommandValidator()
    {
        RuleFor(x => x.Patient.Id).NotEmpty().WithMessage("PatientId is required");
        RuleFor(x => x.Patient.FirstName).NotEmpty().WithMessage("Patient.FirstName is required");
        RuleFor(x => x.Patient.LastName).NotEmpty().WithMessage("Patient.LastName is required");
    }
}

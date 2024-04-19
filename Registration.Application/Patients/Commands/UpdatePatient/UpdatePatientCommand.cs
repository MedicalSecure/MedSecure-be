using BuildingBlocks.CQRS;
using FluentValidation;
using Registration.Application.Dtos;

namespace Registration.Application.Patients.Commands.UpdatePatient
{
    public record UpdatePatientCommand(PatientDto Patient) : ICommand<UpdatePatientResult>;

    public record UpdatePatientResult(bool IsSuccess);

    public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator()
        {
            RuleFor(x => x.Patient.Id).NotEmpty().WithMessage("PatientId is required");
            RuleFor(x => x.Patient.patientName).NotEmpty().WithMessage("Patient.name is required");
            RuleFor(x => x.Patient.gender).NotEmpty().WithMessage("Patient.gender is required");
        }
    }
}

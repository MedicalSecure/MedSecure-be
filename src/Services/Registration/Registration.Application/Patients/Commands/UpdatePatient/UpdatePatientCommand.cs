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
            RuleFor(x => x.Patient.Id).NotEmpty().WithMessage("AssociatedPatientId is required");
            RuleFor(x => x.Patient.FirstName).NotEmpty().WithMessage("Patient.name is required");
            RuleFor(x => x.Patient.Gender).NotEmpty().WithMessage("Patient.gender is required");
        }
    }
}

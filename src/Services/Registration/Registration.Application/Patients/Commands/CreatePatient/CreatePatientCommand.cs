using BuildingBlocks.CQRS;
using FluentValidation;
using Registration.Application.Dtos;


namespace Registration.Application.Patients.Commands.CreatePatient;

public record CreatePatientCommand(PatientDto Patient) : ICommand<CreatePatientResult>;

public record CreatePatientResult(Guid Id);
public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(x => x.Patient.FirstName).NotEmpty().WithMessage("Patient's name is required");
        RuleFor(x => x.Patient.Gender).NotEmpty().WithMessage("Patient's gender is required");
    }
}
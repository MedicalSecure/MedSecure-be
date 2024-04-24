using BuildingBlocks.CQRS;
using FluentValidation;
using Pharmalink.Application.Dtos;

namespace Pharmalink.Application.Medications.Commands.CreateMedication;


public record CreateMedicationCommand(MedicationDto Medication) : ICommand<CreateMedicationResult>;
public record CreateMedicationResult(Guid Id);
public class CreateMedicationCommandValidator : AbstractValidator<CreateMedicationCommand>
{
    public CreateMedicationCommandValidator()
    {
        RuleFor(x => x.Medication.Name)
            .NotEmpty()
            .WithMessage("Medication Name is required");

        RuleFor(x => x.Medication.Dosage)
            .NotEmpty()
            .Matches(@"\d+(\.\d+)?\s*(mg|ml|g|kg|IU|mcg|μg|cc)?$")
            .WithMessage("Medication Dosage should end with a valid unit (mg, ml, g, kg, IU, mcg, cc, etc.)");

        RuleFor(x => x.Medication.Form)
            .NotEmpty()
            .WithMessage("Medication Form is required");

        RuleFor(x => x.Medication.Code)
            .NotEmpty()
            .Matches(@"^[A-Za-z0-9]+$")
            .WithMessage("Medication Code must contain only alphanumeric characters");

        RuleFor(x => x.Medication.Unit)
            .NotEmpty()
            .WithMessage("Medication Unit is required");

        RuleFor(x => x.Medication.Description)
            .NotEmpty()
            .WithMessage("Medication Description is required");

        RuleFor(x => x.Medication.ExpiredAt.Date)
            .NotEmpty()
            .Must(BeInTheFuture)
            .WithMessage("Medication ExpiredAt must be in the future");

        RuleFor(x => x.Medication.Stock)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Medication Stock must be non-negative")
            .GreaterThan(x => x.Medication.AlertStock)
            .WithMessage("Medication Stock should be greater than AlertStock");

        RuleFor(x => x.Medication.AlertStock)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Medication AlertStock must be non-negative")
            .GreaterThan(x => x.Medication.AvrgStock)
            .WithMessage("Medication AlertStock should be greater than AvrgStock");

        RuleFor(x => x.Medication.AvrgStock)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Medication AvrgStock must be non-negative")
            .GreaterThan(x => x.Medication.MinStock)
            .WithMessage("Medication AvrgStock should be greater than MinStock");

        RuleFor(x => x.Medication.MinStock)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Medication MinStock must be non-negative")
            .GreaterThan(x => x.Medication.SafetyStock)
            .WithMessage("Medication MinStock should be greater than SafetyStock");

        RuleFor(x => x.Medication.SafetyStock)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Medication SafetyStock must be non-negative");

        RuleFor(x => x.Medication.ReservedStock)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Medication ReservedStock must be non-negative");
    }

    private bool BeInTheFuture(DateTime date)
    {
        return date > DateTime.Now.Date.AddYears(1);
    }
}


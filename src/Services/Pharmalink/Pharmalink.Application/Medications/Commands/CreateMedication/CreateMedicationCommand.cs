namespace Pharmalink.Application.Medications.Commands.CreateMedication;


public record CreateMedicationCommand(List<MedicationDto> Medications) : ICommand<CreateMedicationResult>;
public record CreateMedicationResult(List<Guid> IDs);
public class CreateMedicationCommandValidator : AbstractValidator<CreateMedicationCommand>
{
    public CreateMedicationCommandValidator()
    {
        RuleFor(x => x.Medications)
            .NotEmpty()
            .WithMessage("At least one medication is required");

        RuleForEach(x => x.Medications)
            .ChildRules(medication =>
            {
                medication.RuleFor(m => m.Name)
                    .NotEmpty()
                    .WithMessage("Medication Name is required");

                medication.RuleFor(m => m.Form)
                    .NotEmpty()
                    .WithMessage("Medication Form is required");

                medication.RuleFor(m => m.Code)
                    .NotEmpty()
                    .Matches(@"^[A-Za-z0-9]+$")
                    .WithMessage("Medication Code must contain only alphanumeric characters");

                medication.RuleFor(m => m.Unit)
                    .NotEmpty()
                    .WithMessage("Medication Unit is required");

                medication.RuleFor(m => m.Description)
                    .NotEmpty()
                    .WithMessage("Medication Description is required");

                medication.RuleFor(m => m.ExpiredAt.Date)
                    .NotEmpty()
                    .Must(BeInTheFuture)
                    .WithMessage("Medication ExpiredAt must be in the future");

                medication.RuleFor(m => m.Stock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Medication Stock must be non-negative")
                    .GreaterThan(m => m.AlertStock)
                    .WithMessage("Medication Stock should be greater than AlertStock");

                medication.RuleFor(m => m.AlertStock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Medication AlertStock must be non-negative")
                    .GreaterThan(m => m.AvrgStock)
                    .WithMessage("Medication AlertStock should be greater than AvrgStock");

                medication.RuleFor(m => m.AvrgStock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Medication AvrgStock must be non-negative")
                    .GreaterThan(m => m.MinStock)
                    .WithMessage("Medication AvrgStock should be greater than MinStock");

                medication.RuleFor(m => m.MinStock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Medication MinStock must be non-negative")
                    .GreaterThan(m => m.SafetyStock)
                    .WithMessage("Medication MinStock should be greater than SafetyStock");

                medication.RuleFor(m => m.SafetyStock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Medication SafetyStock must be non-negative");

                medication.RuleFor(m => m.ReservedStock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Medication ReservedStock must be non-negative");
            });
    }

    private bool BeInTheFuture(DateTime date)
    {
        return date > DateTime.Now.Date.AddYears(1);
    }
}


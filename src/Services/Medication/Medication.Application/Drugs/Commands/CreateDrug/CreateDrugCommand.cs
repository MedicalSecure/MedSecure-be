namespace Medication.Application.Drugs.Commands.CreateDrug;


public record CreateDrugCommand(List<DrugDto> Drugs) : ICommand<CreateDrugResult>;
public record CreateDrugResult(List<Guid> IDs);
public class CreateDrugCommandValidator : AbstractValidator<CreateDrugCommand>
{
    public CreateDrugCommandValidator()
    {
        RuleFor(x => x.Drugs)
            .NotEmpty()
            .WithMessage("At least one drug is required");

        RuleForEach(x => x.Drugs)
            .ChildRules(drug =>
            {
                drug.RuleFor(m => m.Name)
                    .NotEmpty()
                    .WithMessage("drug Name is required");

                drug.RuleFor(m => m.Form)
                    .NotEmpty()
                    .WithMessage("drug Form is required");

                drug.RuleFor(m => m.Code)
                    .NotEmpty()
                    .Matches(@"^[A-Za-z0-9]+$")
                    .WithMessage("drug Code must contain only alphanumeric characters");

                drug.RuleFor(m => m.Unit)
                    .NotEmpty()
                    .WithMessage("drug Unit is required");

                drug.RuleFor(m => m.Description)
                    .NotEmpty()
                    .WithMessage("drug Description is required");

                drug.RuleFor(m => m.ExpiredAt.Date)
                    .NotEmpty()
                    .Must(BeInTheFuture)
                    .WithMessage("drug ExpiredAt must be in the future");

                drug.RuleFor(m => m.Stock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("drug Stock must be non-negative")
                    .GreaterThan(m => m.AlertStock)
                    .WithMessage("drug Stock should be greater than AlertStock");

                drug.RuleFor(m => m.AlertStock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("drug AlertStock must be non-negative")
                    .GreaterThan(m => m.AvrgStock)
                    .WithMessage("drug AlertStock should be greater than AvrgStock");

                drug.RuleFor(m => m.AvrgStock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("drug AvrgStock must be non-negative")
                    .GreaterThan(m => m.MinStock)
                    .WithMessage("drug AvrgStock should be greater than MinStock");

                drug.RuleFor(m => m.MinStock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("drug MinStock must be non-negative")
                    .GreaterThan(m => m.SafetyStock)
                    .WithMessage("drug MinStock should be greater than SafetyStock");

                drug.RuleFor(m => m.SafetyStock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("drug SafetyStock must be non-negative");

                drug.RuleFor(m => m.ReservedStock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("drug ReservedStock must be non-negative");
            });
    }

    private bool BeInTheFuture(DateTime date)
    {
        return date > DateTime.Now.Date.AddYears(1);
    }
}


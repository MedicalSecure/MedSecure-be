namespace Diet.Application.Diets.Commands.CreateDiet;

public record CreateDietCommand(DietDto Diet) : ICommand<CreateDietResult>;

public record CreateDietResult(Guid Id);

public class CreateDietCommandValidator : AbstractValidator<CreateDietCommand>
{
    public CreateDietCommandValidator()
    {
        RuleFor(x => x.Diet.PatientId).NotEmpty().WithMessage("PatientId is required");
        RuleFor(x => x.Diet.EndDate).LessThan(x => x.Diet.StartDate).WithMessage("EndDate should be > StartDate");
        RuleFor(x => x.Diet.Meals).NotEmpty().WithMessage("Meals is should not be empty");
    }
}


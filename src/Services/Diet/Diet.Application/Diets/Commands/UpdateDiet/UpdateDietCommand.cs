
namespace Diet.Application.Diets.Commands.UpdateDiet;

public record UpdateDietCommand(DietDto Diet) : ICommand<UpdateDietResult>;

public record UpdateDietResult(bool IsSuccess);

public class UpdateDietCommandValidator : AbstractValidator<UpdateDietCommand>
{
    public UpdateDietCommandValidator()
    {
        RuleFor(x => x.Diet.Id).NotEmpty().WithMessage("DietId is required");
        RuleFor(x => x.Diet.PatientId).NotEmpty().WithMessage("PatientId is required");
        RuleFor(x => x.Diet.EndDate).LessThan(x => x.Diet.StartDate).WithMessage("EndDate should be > StartDate");
    }
}


namespace Diet.Application.Foods.Commands.UpdateDiet;

public record UpdateFoodCommand(FoodDto Food) : ICommand<UpdateFoodResult>;

public record UpdateFoodResult(bool IsSuccess);

public class UpdateFoodCommandValidator : AbstractValidator<UpdateFoodCommand>
{
    public UpdateFoodCommandValidator()
    {
        RuleFor(x => x.Food.Id).NotEmpty().WithMessage("FoodId is required");
        RuleFor(x => x.Food.Name).NotEmpty().WithMessage("Food.Name is required");
        RuleFor(x => x.Food.Calories).GreaterThan(0).WithMessage("Food.Calories should be > 0");
    }
}

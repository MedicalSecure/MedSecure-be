
namespace Diet.Application.Foods.Commands.CreateFood;

public record CreateFoodCommand(FoodDto Food) : ICommand<CreateFoodResult>;

public record CreateFoodResult(Guid Id);

public class CreateFoodCommandValidator : AbstractValidator<CreateFoodCommand>
{
    public CreateFoodCommandValidator()
    {
        RuleFor(x => x.Food.Name).NotEmpty().WithMessage("Food Name is required");
        RuleFor(x => x.Food.Calories).GreaterThan(0).WithMessage("Food.Calories should be > 0");
    }
}



namespace Diet.Application.Diets.Commands.CreateDiet;

public record CreateDietCommand(DietDto Diet) : ICommand<CreateDietResult>;

public record CreateDietResult(Guid Id);

public class CreateDietCommandValidator : AbstractValidator<CreateDietCommand>
{
    public CreateDietCommandValidator()
    {
    }
}


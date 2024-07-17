
namespace Diet.Application.Diets.Commands.UpdateDiet;

public record UpdateDietCommand(DietDto Diet) : ICommand<UpdateDietResult>;

public record UpdateDietResult(bool IsSuccess);

public class UpdateDietCommandValidator : AbstractValidator<UpdateDietCommand>
{
    public UpdateDietCommandValidator()
    {
     
    }
}

namespace UnitCare.Application.UnitCares.Commands.CreateUnitCare
{
    public record CreateUnitCareCommand(UnitCareDto UnitCare) : ICommand<CreateUnitCareResult>;

    public record CreateUnitCareResult(Guid Id);

    public class CreateUnitCareCommandValidator : AbstractValidator<CreateUnitCareCommand>
    {
        public CreateUnitCareCommandValidator()
        {
            RuleFor(x => x.UnitCare.Title).NotEmpty().WithMessage("Title should not be empty");
            RuleFor(x => x.UnitCare.Type).NotEmpty().WithMessage("Type is required");
            RuleFor(x => x.UnitCare.Rooms).NotEmpty().WithMessage("Rooms is should not be empty");
            RuleFor(x => x.UnitCare.Personnels).NotEmpty().WithMessage("Personnels is should not be empty");
        }
    }

}

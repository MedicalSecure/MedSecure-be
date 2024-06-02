namespace UnitCare.Application.UnitCares.Commands.UpdateUnitCare;

public record UpdateUnitCareCommand(UnitCareDto UnitCare) : ICommand<UpdateUnitCareResult>;

public record UpdateUnitCareResult(bool IsSuccess);

public class UpdateUnitCareCommandValidator : AbstractValidator<UpdateUnitCareCommand>
{
    public UpdateUnitCareCommandValidator()
    {
        RuleFor(x => x.UnitCare.Id).NotEmpty().WithMessage("UnitCareId is required");
        RuleFor(x => x.UnitCare.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.UnitCare.Type).NotEmpty().WithMessage("Type is required");
    }
}


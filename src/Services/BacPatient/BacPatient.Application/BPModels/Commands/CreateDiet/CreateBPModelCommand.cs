namespace BacPatient.Application.BPModels.Commands.CreateDiet;

public record CreateBPModelCommand(BPModelDto BPModel) : ICommand<CreateBPModelResult>;

public record CreateBPModelResult(Guid Id);

public class CreateBPModelCommandValidator : AbstractValidator<CreateBPModelCommand>
{
    public CreateBPModelCommandValidator()
    {
        RuleFor(x => x.BPModel.PatientId).NotEmpty().WithMessage("PatientId is required");
        RuleFor(x => x.BPModel.RoomId).NotEmpty().WithMessage("RoomId is required");
        RuleFor(x => x.BPModel.UnitCareId).NotEmpty().WithMessage("UnitCareId is required");
        RuleFor(x => x.BPModel.Medicines).NotEmpty().WithMessage("Medcicnes is should not be empty");
    }
}


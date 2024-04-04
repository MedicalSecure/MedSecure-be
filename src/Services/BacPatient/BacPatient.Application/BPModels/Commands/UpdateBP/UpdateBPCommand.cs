namespace BacPatient.Application.BPModels.Commands.UpdateDiet;

public record UpdateBPCommand(BPModelDto BPModel) : ICommand<UpdateBPResult>;

public record UpdateBPResult(bool IsSuccess);

public class UpdateBPCommandValidator : AbstractValidator<UpdateBPCommand>
{
    public UpdateBPCommandValidator()
    {
        RuleFor(x => x.BPModel.PatientId).NotEmpty().WithMessage("PatientId is required");
        RuleFor(x => x.BPModel.RoomId).NotEmpty().WithMessage("RoomId is required");
        RuleFor(x => x.BPModel.UnitCareId).NotEmpty().WithMessage("UnitCareId is required");
        RuleFor(x => x.BPModel.Medicines).NotEmpty().WithMessage("Medcicnes is should not be empty");
    }
}

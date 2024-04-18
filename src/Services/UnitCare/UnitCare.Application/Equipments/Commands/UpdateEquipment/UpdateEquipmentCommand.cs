namespace UnitCare.Application.Equipments.Commands.UpdateEquipment;

public record UpdateEquipmentCommand(EquipmentDto Equipment) : ICommand<UpdateEquipmentResult>;

public record UpdateEquipmentResult(bool IsSuccess);

public class UpdateEquipmentCommandValidator : AbstractValidator<UpdateEquipmentCommand>
{
public UpdateEquipmentCommandValidator()
{
    RuleFor(x => x.Equipment.Id).NotEmpty().WithMessage("EquipmentId is required");
    RuleFor(x => x.Equipment.Name).NotEmpty().WithMessage("Equipment.Name is required");
    RuleFor(x => x.Equipment.Reference).NotEmpty().WithMessage("Equipment.Reference is required");
    }
}


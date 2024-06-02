namespace UnitCare.Application.Equipments.Commands.CreateEquipment;

public record CreateEquipmentCommand(EquipmentDto Equipment) : ICommand<CreateEquipmentResult>;

public record CreateEquipmentResult(Guid Id);

public class CreateEquipmentCommandValidator : AbstractValidator<CreateEquipmentCommand>
{
    public CreateEquipmentCommandValidator()
    {
        RuleFor(x => x.Equipment.Name).NotEmpty().WithMessage("Food Name is required");
        RuleFor(x => x.Equipment.Reference).NotEmpty().WithMessage("Equipment Reference is required");
    }
}


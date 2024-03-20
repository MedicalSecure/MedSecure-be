namespace Waste.Application.Wastes.Commands.CreateWaste;

public record CreateRoomCommand(WasteDto Waste) : ICommand<CreateWasteResult>;

public record CreateWasteResult(Guid Id);

public class CreateWasteCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateWasteCommandValidator()
    {
        RuleFor(x => x.Waste.RoomId).NotEmpty().WithMessage("RoomId is required");
        RuleFor(x => x.Waste.PickupLocation).NotEmpty().WithMessage("PickupLocation is should not be empty");
        RuleFor(x => x.Waste.DropOffLocation).NotEmpty().WithMessage("DropOffLocation is should not be empty");
        RuleFor(x => x.Waste.WasteItems).NotEmpty().WithMessage("WasteItems is should not be empty");
    }
}


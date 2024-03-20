
namespace Waste.Application.Wastes.Commands.UpdateWaste;

public record UpdateRoomCommand(WasteDto Waste) : ICommand<UpdateWasteResult>;

public record UpdateWasteResult(bool IsSuccess);

public class UpdateWasteCommandValidator : AbstractValidator<UpdateRoomCommand>
{
    public UpdateWasteCommandValidator()
    {
        RuleFor(x => x.Waste.Id).NotEmpty().WithMessage("DietId is required");
        RuleFor(x => x.Waste.RoomId).NotEmpty().WithMessage("RoomId is required");
        RuleFor(x => x.Waste.PickupLocation).NotEmpty().WithMessage("PickupLocation is should not be empty");
        RuleFor(x => x.Waste.DropOffLocation).NotEmpty().WithMessage("DropOffLocation is should not be empty");
        RuleFor(x => x.Waste.WasteItems).NotEmpty().WithMessage("WasteItems is should not be empty");
    }
}

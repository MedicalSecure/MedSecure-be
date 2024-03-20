
namespace Waste.Application.Rooms.Commands.UpdateRoom;

public record UpdateRoomCommand(RoomDto Room) : ICommand<UpdateRoomResult>;

public record UpdateRoomResult(bool IsSuccess);

public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
{
    public UpdateRoomCommandValidator()
    {
        RuleFor(x => x.Room.Id).NotEmpty().WithMessage("RoomId is required");
        RuleFor(x => x.Room.Name).NotEmpty().WithMessage("RoomId is required");
    }
}

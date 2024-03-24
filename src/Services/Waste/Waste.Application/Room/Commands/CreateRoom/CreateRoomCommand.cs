
namespace Waste.Application.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(RoomDto Room) : ICommand<CreateRoomResult>;

public record CreateRoomResult(Guid Id);

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(x => x.Room.Name).NotEmpty().WithMessage("Room.Name is should not be empty");
        RuleFor(x => x.Room.Description).NotEmpty().WithMessage("Room.Description is should not be empty");
    }
}


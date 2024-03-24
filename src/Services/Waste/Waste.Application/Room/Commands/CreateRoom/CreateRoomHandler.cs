
namespace Waste.Application.Rooms.Commands.CreateRoom;

public class CreateRoomHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateRoomCommand, CreateRoomResult>
{
    public async Task<CreateRoomResult> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
    {
        // create Room entity from command object
        // save to database
        // return result
        var room = CreateNewRoom(command.Room);

        dbContext.Rooms.Add(room);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateRoomResult(room.Id.Value);
    }

    private static Domain.Models.Room CreateNewRoom(RoomDto roomDto)
    {
        var newRoom = Domain.Models.Room.Create(
         id: RoomId.Of(Guid.NewGuid()),
         name: roomDto.Name,
         description: roomDto.Description
     );

        return newRoom;
    }
}

namespace Waste.Application.Rooms.Commands.UpdateRoom;

public class UpdateRoomHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateRoomCommand, UpdateRoomResult>
{
    public async Task<UpdateRoomResult> Handle(UpdateRoomCommand command, CancellationToken cancellationToken)
    {
        // Update Room entity from command object
        // save to database
        // return result
        var roomId = RoomId.Of(command.Room.Id);
        var room = await dbContext.Rooms.FindAsync([roomId], cancellationToken);

        if (room == null)
        {
            throw new RoomNotFoundException(command.Room.Id);
        }

        UpdateRoomWithNewValues(room, command.Room);

        dbContext.Rooms.Update(room);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateRoomResult(true);
    }
    private static void UpdateRoomWithNewValues(Domain.Models.Room room, RoomDto roomDto)
    {
        room.Update(roomDto.Name, roomDto.Description);
    }
}
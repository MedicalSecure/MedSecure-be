
namespace Waste.Application.Extensions;

public static partial class RoomExtensions
{
    public static IEnumerable<RoomDto> ToRoomDto(this List<Room> rooms)
    {
        return rooms.Select(f => new RoomDto(
            Id: f.Id.Value,
            Name: f.Name,
            Description: f.Description));
    }
}
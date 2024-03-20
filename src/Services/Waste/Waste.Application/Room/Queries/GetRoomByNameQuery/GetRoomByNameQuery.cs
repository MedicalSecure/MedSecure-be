
namespace Waste.Application.Rooms.Queries.GetRoomByNameQuery
{
    public record GetRoomByNameQuery(string Name) : IQuery<GetRoomByNameResult>;

    public record GetRoomByNameResult(IEnumerable<RoomDto> Rooms);
}

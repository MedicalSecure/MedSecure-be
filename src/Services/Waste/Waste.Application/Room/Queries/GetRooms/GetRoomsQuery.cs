
namespace Waste.Application.Rooms.Queries.GetRooms;

public record GetRoomsQuery(PaginationRequest PaginationRequest)
: IQuery<GetRoomsResult>;

public record GetRoomsResult(PaginatedResult<RoomDto> Rooms);
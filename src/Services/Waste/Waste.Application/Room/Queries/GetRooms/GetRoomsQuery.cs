
public record GetRoomsQuery(PaginationRequest PaginationRequest)
: IQuery<GetRoomsResult>;

public record GetRoomsResult(PaginatedResult<RoomDto> Rooms);

namespace Waste.Application.Rooms.Queries.GetRooms;

public class GetRoomsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetRoomsQuery, GetRoomsResult>
{
    public async Task<GetRoomsResult> Handle(GetRoomsQuery query, CancellationToken cancellationToken)
    {
        // get Room with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Rooms.LongCountAsync(cancellationToken);

        var rooms = await dbContext.Rooms
                       .OrderBy(o => o.Name)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);
        return new GetRoomsResult(
            new PaginatedResult<RoomDto>(
                pageIndex,
                pageSize,
                totalCount,
                rooms.ToRoomDto()));
    }
}
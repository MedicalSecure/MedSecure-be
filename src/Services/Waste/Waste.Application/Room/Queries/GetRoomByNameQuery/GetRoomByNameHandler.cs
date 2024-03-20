
namespace Waste.Application.Rooms.Queries.GetRoomByNameQuery;

public class GetRoomByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetRoomByNameQuery, GetRoomByNameResult>
{
    public async Task<GetRoomByNameResult> Handle(GetRoomByNameQuery query, CancellationToken cancellationToken)
    {
        // get Rooms by Id using dbContext
        // return result
        var rooms = await dbContext.Rooms
             .AsNoTracking()
             .Where(o => o.Name.Contains(query.Name))
             .OrderBy(o => o.Id)
             .ToListAsync(cancellationToken);

        return new GetRoomByNameResult(rooms.ToRoomDto());
    }
}
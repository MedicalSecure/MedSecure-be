
namespace Waste.Application.Wastes.Queries.GetWasteByRoomIdQuery;

public class GetWasteByRoomIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetWasteByRoomIdQuery, GetWasteByRoomIdResult>
{
    public async Task<GetWasteByRoomIdResult> Handle(GetWasteByRoomIdQuery query, CancellationToken cancellationToken)
    {
        // get wastes by Id using dbContext
        // return result
        var wastes = await dbContext.Wastes
             .Include(o => o.WasteItems)
             .AsNoTracking()
             .Where(o => o.RoomId == RoomId.Of(query.id))
             .OrderBy(o => o.Id)
             .ToListAsync(cancellationToken);

        return new GetWasteByRoomIdResult(wastes.ToWasteDto());
    }
}
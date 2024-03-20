
namespace Waste.Application.Wastes.Queries.GetWastes;

public class GetWastesHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetWastesQuery, GetWastesResult>
{
    public async Task<GetWastesResult> Handle(GetWastesQuery query, CancellationToken cancellationToken)
    {
        // get Wastes with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Wastes.LongCountAsync(cancellationToken);

        var wastes = await dbContext.Wastes
                       .Include(o => o.WasteItems)
                       .OrderBy(o => o.RoomId.Value)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);
        return new GetWastesResult(
            new PaginatedResult<WasteDto>(
                pageIndex,
                pageSize,
                totalCount,
                wastes.ToWasteDto()));
    }
}
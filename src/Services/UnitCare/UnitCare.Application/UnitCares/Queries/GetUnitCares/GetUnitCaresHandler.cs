namespace UnitCare.Application.UnitCares.Queries.GetUnitCares;

public class GetUnitCaresHandler(IApplicationDbContext dbContext)
: IQueryHandler<GetUnitCaresQuery, GetUnitCaresResult>
{
    public async Task<GetUnitCaresResult> Handle(GetUnitCaresQuery query, CancellationToken cancellationToken)
    {
        // get unitcares with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.UnitCares.LongCountAsync(cancellationToken);

        var unitcares = await dbContext.UnitCares
                       .Include(o => o.Rooms)
                       .ThenInclude(f => f.Equipments)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetUnitCaresResult(
            new PaginatedResult<UnitCareDto>(
                pageIndex,
                pageSize,
                totalCount,
                unitcares.ToUnitCareDto()));
    }
}

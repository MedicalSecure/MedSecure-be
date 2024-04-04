namespace BacPatient.Application.BPModels.Queries.GetDiets;

public class GetDietsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetDietsQuery, GetDietsResult>
{
    public async Task<GetDietsResult> Handle(GetDietsQuery query, CancellationToken cancellationToken)
    {
        // get diets with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Diets.LongCountAsync(cancellationToken);

        var diets = await dbContext.Diets
                       .Include(o => o.Meals)
                       .ThenInclude(f => f.Foods)
                       .OrderBy(o => o.PatientId)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetDietsResult(
            new PaginatedResult<DietDto>(
                pageIndex,
                pageSize,
                totalCount,
                diets.ToDietDto()));
    }
}
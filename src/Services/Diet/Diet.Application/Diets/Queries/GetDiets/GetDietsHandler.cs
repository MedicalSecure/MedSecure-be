
namespace Diet.Application.Diets.Queries.GetDiets;

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
                       .Include(o => o.DailyMeals)
                       .ThenInclude(d => d.Meals)
                       .ThenInclude(f=> f.Foods)
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
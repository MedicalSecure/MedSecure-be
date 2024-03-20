
namespace Diet.Application.Diets.Queries.GetDiets;

public class GetFoodsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetFoodsQuery, GetDietsResult>
{
    public async Task<GetDietsResult> Handle(GetFoodsQuery query, CancellationToken cancellationToken)
    {
        // get diets with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Diets.LongCountAsync(cancellationToken);

        var diets = await dbContext.Diets
                       .Include(o => o.Meals)
                       .OrderBy(o => o.PatientId.Value)
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
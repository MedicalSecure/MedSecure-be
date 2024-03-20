
namespace Diet.Application.Diets.Queries.GetFoods;

public class GetFoodsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetFoodsQuery, GetFoodsResult>
{
    public async Task<GetFoodsResult> Handle(GetFoodsQuery query, CancellationToken cancellationToken)
    {
        // get foods with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Foods.LongCountAsync(cancellationToken);

        var foods = await dbContext.Foods
                       .OrderBy(o => o.Name)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetFoodsResult(
            new PaginatedResult<FoodDto>(
                pageIndex,
                pageSize,
                totalCount,
                foods.ToFoodDto()));
    }
}
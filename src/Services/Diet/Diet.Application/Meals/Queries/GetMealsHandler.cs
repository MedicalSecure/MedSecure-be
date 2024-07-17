
namespace Diet.Application.Meals.Queries;

public class GetMealsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetMealQuery, GetMealResult>
{
    public async Task<GetMealResult> Handle(GetMealQuery query, CancellationToken cancellationToken)
    {
        // get Meals with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Meals.LongCountAsync(cancellationToken);

        var Meals = await dbContext.Meals
                       .OrderBy(o => o.Name)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetMealResult(
            new PaginatedResult<MealDto>(
                pageIndex,
                pageSize,
                totalCount,
                Meals.ToMealsDto()));
    }
}
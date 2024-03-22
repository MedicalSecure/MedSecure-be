
namespace Diet.Application.Diets.Queries.GetFoodByNameQuery;

public class GetFoodByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetFoodByNameQuery, GetFoodByNameResult>
{
    public async Task<GetFoodByNameResult> Handle(GetFoodByNameQuery query, CancellationToken cancellationToken)
    {
        // get foods by Id using dbContext
        // return result
        var foods = await dbContext.Foods
             .AsNoTracking()
             .Where(o => o.Name.Contains(query.name))
             .OrderBy(o => o.Id)
             .ToListAsync(cancellationToken);

        return new GetFoodByNameResult(foods.ToFoodDto());
    }
}
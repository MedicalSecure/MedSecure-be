
using Diet.Application.Extensions;

namespace Diet.Application.Diets.Queries.GetDietByIdQuery;

public class GetFoodByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetFoodByNameQuery, GetDietByPatientIdResult>
{
    public async Task<GetDietByPatientIdResult> Handle(GetFoodByNameQuery query, CancellationToken cancellationToken)
    {
        // get diets by Id using dbContext
        // return result
        var diets = await dbContext.Diets
             .Include(o => o.Meals)
             .AsNoTracking()
             .Where(o => o.PatientId == PatientId.Of(query.id))
             .OrderBy(o => o.Id)
             .ToListAsync(cancellationToken);

        return new GetDietByPatientIdResult(diets.ToDietDto());
    }
}
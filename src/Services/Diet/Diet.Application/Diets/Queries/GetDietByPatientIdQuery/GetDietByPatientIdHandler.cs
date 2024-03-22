
namespace Diet.Application.Diets.Queries.GetDietByPatientIdQuery;

public class GetDietByPatientIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetDietByPatientIdQuery, GetDietByPatientIdResult>
{
    public async Task<GetDietByPatientIdResult> Handle(GetDietByPatientIdQuery query, CancellationToken cancellationToken)
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
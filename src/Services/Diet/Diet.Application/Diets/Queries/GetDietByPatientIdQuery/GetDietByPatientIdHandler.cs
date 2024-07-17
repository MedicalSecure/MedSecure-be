

namespace Diet.Application.Diets.Queries.GetDietByPatientIdQuery;

public class GetDietByPatientIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetDietByPatientIdQuery, GetDietByPatientIdResult>
{
    public async Task<GetDietByPatientIdResult> Handle(GetDietByPatientIdQuery query, CancellationToken cancellationToken)
    {
        // get diets by Id using dbContext
        // var patients = await dbContext.Patients;
        // return result
        var diets = await dbContext.Diets
             .Include(o => o.Meals)
             .ThenInclude(c=> c.Foods)
             .AsNoTracking()
             .Where(o => o.Register.Patient.Id == PatientId.Of(query.id))
             .OrderBy(o => o.Id)
             .ToListAsync(cancellationToken);

        return new GetDietByPatientIdResult(diets.ToDietDto());
    }
}
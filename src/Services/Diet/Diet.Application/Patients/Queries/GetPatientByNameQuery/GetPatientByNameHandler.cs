
namespace Diet.Application.Patients.Queries.GetPatientByNameQuery;

public class GetPatientByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetPatientByNameQuery, GetPatientByNameResult>
{
    public async Task<GetPatientByNameResult> Handle(GetPatientByNameQuery query, CancellationToken cancellationToken)
    {
        // get patients by Id using dbContext
        // return result
        var patients = await dbContext.Patients
             .AsNoTracking()
             .Where(o => o.FirstName.Contains(query.name) || o.LastName.Contains(query.name))
             .OrderBy(o => o.DateOfBirth)
             .ToListAsync(cancellationToken);

        return new GetPatientByNameResult(patients.ToPatientDto());
    }
}
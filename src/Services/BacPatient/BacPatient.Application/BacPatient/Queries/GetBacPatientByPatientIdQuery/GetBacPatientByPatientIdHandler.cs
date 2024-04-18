namespace BacPatient.Application.BacPatient.Queries.GetBacPatientByPatientIdQuery;

public class GetBacPatientByPatientIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetBPatientByPatientIdQuery, GetBPByPatientIdResult>
{
    public async Task<GetBPByPatientIdResult> Handle(GetBPatientByPatientIdQuery query, CancellationToken cancellationToken)
    {
        // get diets by Id using dbContext
        // return result
        var bacPatients = await dbContext.BacPatients
             .Include(o => o.Medicines)
             .AsNoTracking()
             .Where(o => o.PatientId == PatientId.Of(query.id))
             .OrderBy(o => o.Id)
             .ToListAsync(cancellationToken);

        return new GetBPByPatientIdResult(bacPatients.ToBacPatientDtos());
    }
}
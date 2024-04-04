namespace BacPatient.Application.BPModels.Queries.GetDietByPatientIdQuery;

public class GetBPByPatientIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetBPByPatientIdQuery, GetBPByPatientIdResult>
{
    public async Task<GetBPByPatientIdResult> Handle(GetBPByPatientIdQuery query, CancellationToken cancellationToken)
    {
        // get diets by Id using dbContext
        // return result
        var bps = await dbContext.BacPatients
             .Include(o => o.Medicines)
             .AsNoTracking()
             .Where(o => o.PatientId == PatientId.Of(query.id))
             .OrderBy(o => o.Id)
             .ToListAsync(cancellationToken);

        return new GetBPByPatientIdResult(bps.TobPModelDtos());
    }
}
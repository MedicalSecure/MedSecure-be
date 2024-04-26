using BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using Registration.Application.Data;
using Registration.Application.Extensions;


namespace Registration.Application.Patients.Queries.GetPatientByName;
public class GetPatientByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetPatientByNameQuery, GetPatientByNameResult>
{
    public async Task<GetPatientByNameResult> Handle(GetPatientByNameQuery query, CancellationToken cancellationToken)
    {
        // get patients by Id using dbContext
        // return result

        var patients = await dbContext.Patients
             .AsNoTracking()
             .Where(o => o.FirstName.Contains(query.name) )
             .OrderBy(o => o.DateOfBirth)
             .ToListAsync(cancellationToken);

        return new GetPatientByNameResult(patients.ToPatientDto());
    }
}

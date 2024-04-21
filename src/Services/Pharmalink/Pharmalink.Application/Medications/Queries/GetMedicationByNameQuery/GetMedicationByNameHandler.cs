using BuildingBlocks.CQRS;
using Pharmalink.Application.Data;
using Pharmalink.Application.Extensions;

namespace Pharmalink.Application.Medications.Queries.GetMedicationByNameQuery;

public class GetMedicationByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetMedicationByNameQuery, GetMedicationByNameResult>
{

    public async Task<GetMedicationByNameResult> Handle(GetMedicationByNameQuery query, CancellationToken cancellationToken)
    {
        // get medications by Id using dbContext
        // return result
        var medications = await dbContext.Medications
            .AsNoTracking()
            .Where(m => m.Name.Contains(query.name))
            .OrderBy(m => m.Id)
            .ToListAsync(cancellationToken);

        return new GetMedicationByNameResult(medications.ToMedciationDto());
    }
        
}

using BuildingBlocks.CQRS;
using Pharmalink.Application.Data;
using Pharmalink.Application.Extensions;

namespace Pharmalink.Application.Medications.Queries.GetMedicationByCodeQuery;

public class GetMedicationByCodeHandler(IApplicationDbContext dbContext) : IQueryHandler<GetMedicationByCodeQuery, GetMedicationByCodeResult>
{

    public async Task<GetMedicationByCodeResult> Handle(GetMedicationByCodeQuery query, CancellationToken cancellationToken)
    {
        // get medications by Id using dbContext
        // return result
        var medications = await dbContext.Medications
            .AsNoTracking()
            .Where(m => m.Code.Contains(query.code))
            .OrderBy(m => m.Id)
            .ToListAsync(cancellationToken);

        return new GetMedicationByCodeResult(medications.ToMedciationDto());
    }

}

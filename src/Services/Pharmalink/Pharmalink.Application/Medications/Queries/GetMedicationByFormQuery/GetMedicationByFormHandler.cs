using BuildingBlocks.CQRS;
using Pharmalink.Application.Data;
using Pharmalink.Application.Extensions;

namespace Pharmalink.Application.Medications.Queries.GetMedicationByFormQuery;

public class GetMedicationByFormHandler(IApplicationDbContext dbContext) : IQueryHandler<GetMedicationByFormQuery, GetMedicationByFormResult>
{

    public async Task<GetMedicationByFormResult> Handle(GetMedicationByFormQuery query, CancellationToken cancellationToken)
    {
        // get medications by Id using dbContext
        // return result
        var medications = await dbContext.Medications
            .AsNoTracking()
            .Where(m => m.Form.Contains(query.form))
            .OrderBy(m => m.Id)
            .ToListAsync(cancellationToken);

        return new GetMedicationByFormResult(medications.ToMedciationDto());
    }

}

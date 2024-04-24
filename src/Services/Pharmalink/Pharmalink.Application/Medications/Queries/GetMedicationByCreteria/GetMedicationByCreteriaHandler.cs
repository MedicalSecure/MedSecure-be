using BuildingBlocks.CQRS;
using Pharmalink.Application.Data;
using Pharmalink.Application.Extensions;
using Pharmalink.Domain.Models;

namespace Pharmalink.Application.Medications.Queries.GetMedicationByCreteria;

public class GetMedicationByCreteriaHandler(IApplicationDbContext dbContext) : IQueryHandler<GetMedicationByCreteriaQuery, GetMedicationByCreteriaResult>
{

    public async Task<GetMedicationByCreteriaResult> Handle(GetMedicationByCreteriaQuery getMedicationByCreteriaQuery, CancellationToken cancellationToken)
    {
        // get medications by Id using dbContext
        // return result

        IQueryable<Medication> query = dbContext.Medications.AsNoTracking();

        // Apply filters based on provided criteria
        if (!string.IsNullOrWhiteSpace(getMedicationByCreteriaQuery.creteria.Name))
        {
            query = query.Where(m => m.Name.Contains(getMedicationByCreteriaQuery.creteria.Name));
        }

        else if (!string.IsNullOrWhiteSpace(getMedicationByCreteriaQuery.creteria.Form))
        {
            query = query.Where(m => m.Form.Contains(getMedicationByCreteriaQuery.creteria.Form));
        }

        else if (!string.IsNullOrWhiteSpace(getMedicationByCreteriaQuery.creteria.Code))
        {
            query = query.Where(m => m.Code.Contains(getMedicationByCreteriaQuery.creteria.Code));
        }
        var medications = await query
            .OrderBy(m => m.Id)
            .ToListAsync(cancellationToken);

        return new GetMedicationByCreteriaResult(medications.ToMedciationDto());
    }

}

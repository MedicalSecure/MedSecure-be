namespace Pharmalink.Application.Medications.Queries.MedicationSearch;

public class MedicationSearchHandler(IApplicationDbContext dbContext) : IQueryHandler<MedicationSearchQuery, MedicationSearchResult>
{
    public async Task<MedicationSearchResult> Handle(MedicationSearchQuery medicationSearchQuery, CancellationToken cancellationToken)
    {
        // get medications by Id using dbContext
        // return result

        IQueryable<Medication> query = dbContext.Medications.AsNoTracking();

        // Apply filters based on provided criteria
        if (!string.IsNullOrWhiteSpace(medicationSearchQuery.creteria.Name))
        {
            query = query.Where(m => m.Name.Contains(medicationSearchQuery.creteria.Name));
        }

        if (!string.IsNullOrWhiteSpace(medicationSearchQuery.creteria.Form))
        {
            query = query.Where(m => m.Form.Contains(medicationSearchQuery.creteria.Form));
        }

        if (!string.IsNullOrWhiteSpace(medicationSearchQuery.creteria.Code))
        {
            query = query.Where(m => m.Code.Contains(medicationSearchQuery.creteria.Code));
        }
        var medications = await query
            .OrderBy(m => m.Id)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new MedicationSearchResult(medications.ToMedciationDto());
    }

}

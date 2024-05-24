namespace Medication.Application.Drugs.Queries.SearchDrug;


public class SearchDrugHandler(IApplicationDbContext dbContext) : IQueryHandler<SearchDrugQuery, SearchDrugResult>
{
    public async Task<SearchDrugResult> Handle(SearchDrugQuery searchDrugQuery, CancellationToken cancellationToken)
    {
        // get medications by Id using dbContext
        // return result

        IQueryable<Drug> query = dbContext.Drugs.AsNoTracking();

        // Apply filters based on provided criteria
        if (!string.IsNullOrWhiteSpace(searchDrugQuery.creteria.Name))
        {
            query = query.Where(m => m.Name.Contains(searchDrugQuery.creteria.Name));
        }

        if (!string.IsNullOrWhiteSpace(searchDrugQuery.creteria.Form))
        {
            query = query.Where(m => m.Form.Contains(searchDrugQuery.creteria.Form));
        }

        if (!string.IsNullOrWhiteSpace(searchDrugQuery.creteria.Code))
        {
            query = query.Where(m => m.Code.Contains(searchDrugQuery.creteria.Code));
        }
        var drugs = await query
            .OrderBy(m => m.Id)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new SearchDrugResult(drugs.ToDrugDto());
    }

}

namespace Medication.Application.Drugs.Queries.GetDrugs;


public class GetDrugsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetDrugsQuery, GetDrugsResult>
{
    public async Task<GetDrugsResult> Handle(GetDrugsQuery query, CancellationToken cancellationToken)
    {
        // get drugs with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Drugs.LongCountAsync(cancellationToken);

        var drugs = await dbContext.Drugs
                       .OrderBy(m => m.Name)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetDrugsResult(
            new PaginatedResult<DrugDto>(
                pageIndex,
                pageSize,
                totalCount,
                drugs.ToDrugDto()));
    }
}

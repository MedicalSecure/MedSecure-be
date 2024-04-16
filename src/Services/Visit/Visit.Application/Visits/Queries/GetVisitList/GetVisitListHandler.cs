

namespace Visit.Application.Visits.Queries.GetVisitList;

public record GetVisitListHandler(IApplicationDbContext dbContext)
    :IQueryHandler<GetVisitListQuery, GetVisitListResult>
{
    public async Task<GetVisitListResult> Handle(GetVisitListQuery query, CancellationToken cancellationToken)
    {
        // get visits with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Visits.LongCountAsync(cancellationToken);
        var visits = await dbContext.Visits
         
           .OrderBy(d => d.PatientId)
           .Skip(pageSize * pageIndex)
           .Take(pageSize)
           .ToListAsync(cancellationToken);

        return new GetVisitListResult(
                    new PaginatedResult<VisitDto>(
              pageIndex,
              pageSize,
              totalCount,
              visits.ToVisitDto()));
    }
}

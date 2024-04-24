
namespace Visit.Application.Visits.Queries.GetVisits;

public record GetVisitsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetVisitsQuery, GetVisitsResult>
{
    public async Task<GetVisitsResult> Handle(GetVisitsQuery query, CancellationToken cancellationToken)
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

        return new GetVisitsResult(
                    new PaginatedResult<VisitDto>(
              pageIndex,
              pageSize,
              totalCount,
              visits.ToVisitDto()));
    }
}

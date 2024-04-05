using BacPatient.Application.BPModels.Queries.GetBPQuery;

namespace BacPatient.Application.BPModels.Queries.GetBPHandler;

public class GetBPHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBacPatientQuery, GetBPResult>
{
    public async Task<GetBPResult> Handle(GetBacPatientQuery query, CancellationToken cancellationToken)
    {
        // get diets with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.BacPatients.LongCountAsync(cancellationToken);

        var bp = await dbContext.BacPatients
                       .Include(o => o.Medicines)
                       .ThenInclude(f => f.Posologies)
                       .OrderBy(o => o.PatientId)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetBPResult(
            new PaginatedResult<BPModelDto>(
                pageIndex,
                pageSize,
                totalCount,
                bp.TobPModelDtos()));
    }
}
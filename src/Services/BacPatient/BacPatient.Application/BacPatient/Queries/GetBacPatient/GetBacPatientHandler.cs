
using BacPatient.Application.BacPatient.Queries.GetBacPatient;

namespace BacPatient.Application.BacPatient.Queries.GetBPHandler;

public class GetBacPatientHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBacPatientQuery, GetBacPatientResult>
{
    public async Task<GetBacPatientResult> Handle(GetBacPatientQuery query, CancellationToken cancellationToken)
    {
        // get diets with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.BacPatients.LongCountAsync(cancellationToken);

        var bacPatients = await dbContext.BacPatients
             .Include(bp => bp.Prescription)
             .Include(bp => bp.Room)
        
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetBacPatientResult(
            new PaginatedResult<BacPatientDto>(
                pageIndex,
                pageSize,
                totalCount,
                bacPatients.ToBacPatientDtos()));
    }
}
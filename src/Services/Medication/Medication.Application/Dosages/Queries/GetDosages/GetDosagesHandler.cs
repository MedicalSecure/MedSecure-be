using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Medication.Application.Data;
using Medication.Application.Dtos;

namespace Medication.Application.Dosages.Queries.GetDosages;

public class GetDosagesHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetDosagesQuery, GetDosagesResult>
{
    public async Task<GetDosagesResult> Handle(GetDosagesQuery query, CancellationToken cancellationToken)
    {
        // get dosages with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Dosages.LongCountAsync(cancellationToken);

        var dosages = await dbContext.Dosages
                       .OrderBy(m => m.Code)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetDosagesResult(
            new PaginatedResult<DosageDto>(
                pageIndex,
                pageSize,
                totalCount,
                dosages.ToDosageDto()));
    }
}

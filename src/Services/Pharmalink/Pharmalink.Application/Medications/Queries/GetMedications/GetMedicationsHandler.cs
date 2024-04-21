using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Pharmalink.Application.Data;
using Pharmalink.Application.Dtos;
using Pharmalink.Application.Extensions;

namespace Pharmalink.Application.Medications.Queries.GetMedications;

public class GetMedicationsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetMedicationsQuery, GetMedicationsResult>
{
    public async Task<GetMedicationsResult> Handle(GetMedicationsQuery query, CancellationToken cancellationToken)
    {
        // get medications with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Medications.LongCountAsync(cancellationToken);

        var patients = await dbContext.Medications
                       .OrderBy(m => m.Name)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetMedicationsResult(
            new PaginatedResult<MedicationDto>(
                pageIndex,
                pageSize,
                totalCount,
                patients.ToMedciationDto()));
    }
}

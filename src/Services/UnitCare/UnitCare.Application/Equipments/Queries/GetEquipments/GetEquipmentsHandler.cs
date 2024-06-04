using UnitCare.Application.Dtos;
using UnitCare.Application.Extensions;

namespace UnitCare.Application.Equipments.Queries.GetEquipments;

public class GetEquipmentsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetEquipmentsQuery, GetEquipmentsResult>
{
    public async Task<GetEquipmentsResult> Handle(GetEquipmentsQuery query, CancellationToken cancellationToken)
    {
        // get equipments with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Equipments.LongCountAsync(cancellationToken);

        var equipments = await dbContext.Equipments
                       .OrderBy(o => o.Name)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);
        return new GetEquipmentsResult(
            new PaginatedResult<EquipmentDto>(
                pageIndex,
                pageSize,
        totalCount,
                equipments.ToEquipmentDto()));
    }
}

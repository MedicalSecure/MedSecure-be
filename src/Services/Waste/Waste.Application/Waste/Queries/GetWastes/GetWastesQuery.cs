
namespace Waste.Application.Waste.Queries.GetWastes;

public record GetWastesQuery(PaginationRequest PaginationRequest)
: IQuery<GetWastesResult>;

public record GetWastesResult(PaginatedResult<WasteDto> Wastes);

namespace Diet.Application.Diets.Queries.GetDiets;

public record GetDietsQuery(PaginationRequest PaginationRequest)
: IQuery<GetDietsResult>;

public record GetDietsResult(PaginatedResult<DietDto> Orders);
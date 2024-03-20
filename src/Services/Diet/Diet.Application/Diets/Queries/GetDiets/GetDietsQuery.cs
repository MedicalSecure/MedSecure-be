
namespace Diet.Application.Diets.Queries.GetDiets;

public record GetFoodsQuery(PaginationRequest PaginationRequest)
: IQuery<GetDietsResult>;

public record GetDietsResult(PaginatedResult<DietDto> Orders);
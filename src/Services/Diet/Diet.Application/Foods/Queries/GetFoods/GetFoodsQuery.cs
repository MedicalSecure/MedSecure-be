
namespace Diet.Application.Diets.Queries.GetFoods;

public record GetFoodsQuery(PaginationRequest PaginationRequest)
: IQuery<GetFoodsResult>;

public record GetFoodsResult(PaginatedResult<FoodDto> Foods);
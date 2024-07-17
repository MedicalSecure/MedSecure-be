

namespace Diet.Application.Meals.Queries;
public record GetMealQuery(PaginationRequest PaginationRequest)
: IQuery<GetMealResult>;

public record GetMealResult(PaginatedResult<MealDto> Meals);
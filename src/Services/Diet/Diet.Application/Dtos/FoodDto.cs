
namespace Diet.Application.Dtos;

public record FoodDto(Guid Id, Guid MealId, string Name, decimal Calories, string Description , FoodCategory FoodCategory);

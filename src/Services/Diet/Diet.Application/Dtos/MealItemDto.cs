
namespace Diet.Application.Dtos;

public record MealItemDto(Guid Id, Guid MealId, Guid FoodId, MealCategory MealCategory);

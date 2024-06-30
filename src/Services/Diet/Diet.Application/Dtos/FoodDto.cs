
namespace Diet.Application.Dtos;

public record FoodDto(Guid Id, string? Name, decimal? Calories, string? Description , FoodCategory? FoodCategory);

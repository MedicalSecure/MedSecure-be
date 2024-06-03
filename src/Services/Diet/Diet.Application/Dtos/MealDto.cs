
namespace Diet.Application.Dtos;

public record MealDto(Guid Id, string Name, MealType MealType, List<FoodDto> Foods, List<SimpleCommentsDto> Comments);


namespace Diet.Application.Dtos;

public record MealDto(Guid Id, Guid DietId, string Name, MealType MealType, List<MealItemDto> MealItems);

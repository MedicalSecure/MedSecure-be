
namespace Diet.Application.Dtos;

public record DietDto(Guid Id, SimpleRegisterDto? Register, DietType? DietType, DateTime? StartDate, DateTime? EndDate, List<MealDto?> Meals , string? Label);

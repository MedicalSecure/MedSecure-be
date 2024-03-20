
namespace Diet.Application.Dtos;

public record DietDto(Guid Id, Guid PatientId, DietType DietType, DateTime StartDate, DateTime EndDate, List<MealDto> Meals);

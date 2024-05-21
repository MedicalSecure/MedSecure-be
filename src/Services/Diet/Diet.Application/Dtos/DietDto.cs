
namespace Diet.Application.Dtos;

public record DietDto(Guid Id, SimplePrescriptionDto Prescription, DietType DietType, DateTime StartDate, DateTime EndDate, List<DailyMealDto> Meals , string Label);

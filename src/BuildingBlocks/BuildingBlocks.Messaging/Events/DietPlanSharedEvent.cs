namespace BuildingBlocks.Messaging.Events;

public record DietPlanSharedEvent : IntegrationEvent
{
    public Guid Id { get; init; } = default!;
    public Guid PatientId { get; init; } = default!;
    public DateTime StartDate { get; init; } = default!;
    public DateTime EndDate { get; init; } = default!;
    public List<MealShared> Meals { get; init; } = default!;
}

public record MealShared
{
    public Guid Id { get; init; } = default!;
    public string MealName { get; init; } = default!;
    public string MealType { get; init; } = default!;
    public List<FoodShared> Foods { get; init; } = default!;
}

public record FoodShared
{
    public Guid Id { get; init; } = default!;
    public string FoodName { get; init; } = default!;
    public decimal Calories { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string FoodCategory { get; init; } = default!;
}
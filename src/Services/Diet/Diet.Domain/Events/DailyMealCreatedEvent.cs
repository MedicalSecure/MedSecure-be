namespace Diet.Domain.Events;

public record DailyMealCreatedEvent(Models.DailyMeal dietMeal) : IDomainEvent;

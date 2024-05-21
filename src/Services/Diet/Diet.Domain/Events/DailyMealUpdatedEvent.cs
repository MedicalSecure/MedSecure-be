namespace Diet.Domain.Events;

public record DailyMealUpdatedEvent(Models.DailyMeal DailyMeal) : IDomainEvent;

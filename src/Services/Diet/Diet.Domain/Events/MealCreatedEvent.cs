namespace Diet.Domain.Events;

public record MealCreatedEvent(Models.Meal meal) : IDomainEvent;

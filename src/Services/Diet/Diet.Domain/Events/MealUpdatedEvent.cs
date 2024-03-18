namespace Diet.Domain.Events;

public record MealUpdatedEvent(Meal meal) : IDomainEvent;
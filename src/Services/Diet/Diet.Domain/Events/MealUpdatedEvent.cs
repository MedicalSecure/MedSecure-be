namespace Diet.Domain.Events;

public record MealUpdatedEvent(Models.Meal meal) : IDomainEvent;

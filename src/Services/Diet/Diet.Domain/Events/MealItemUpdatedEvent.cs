namespace Diet.Domain.Events;

public record MealItemUpdatedEvent(MealItem mealItem) : IDomainEvent;

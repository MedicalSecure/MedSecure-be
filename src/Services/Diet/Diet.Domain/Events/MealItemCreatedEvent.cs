
namespace Diet.Domain.Events;

public record MealItemCreatedEvent(MealItem mealItem) : IDomainEvent;


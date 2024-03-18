
namespace Diet.Domain.Events;

public record MealCreatedEvent(Meal meal) : IDomainEvent;
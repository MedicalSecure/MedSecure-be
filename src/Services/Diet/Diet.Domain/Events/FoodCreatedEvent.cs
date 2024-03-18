
namespace Diet.Domain.Events;

public record FoodCreatedEvent(Food food) : IDomainEvent;


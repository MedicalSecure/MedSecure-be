namespace Diet.Domain.Events;

public record FoodUpdatedEvent(Food food) : IDomainEvent;

namespace Waste.Domain.Events;

public record ProductCreatedEvent(Product Product) : IDomainEvent;

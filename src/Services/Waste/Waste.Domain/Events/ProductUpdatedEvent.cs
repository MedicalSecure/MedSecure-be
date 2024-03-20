namespace Waste.Domain.Events;

public record ProductUpdatedEvent(Product Product) : IDomainEvent;

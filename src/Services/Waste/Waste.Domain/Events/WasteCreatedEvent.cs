namespace Waste.Domain.Events;

public record WasteCreatedEvent(Models.Waste Waste) : IDomainEvent;

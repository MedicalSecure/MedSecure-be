namespace Waste.Domain.Events;

public record WasteUpdatedEvent(Models.Waste Waste) : IDomainEvent;

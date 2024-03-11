namespace Waste.Domain.Events;

public record WasteUpdatedEvent(Models.Waste waste) : IDomainEvent;

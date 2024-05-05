namespace Pharmalink.Domain.Events;

public record DosageUpdatedEvent(Dosage dosage) : IDomainEvent;

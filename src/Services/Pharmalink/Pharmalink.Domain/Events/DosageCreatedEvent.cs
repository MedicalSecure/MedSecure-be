namespace Pharmalink.Domain.Events;

public record DosageCreatedEvent(Dosage dosage) : IDomainEvent;

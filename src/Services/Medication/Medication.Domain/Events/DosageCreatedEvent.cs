namespace Medication.Domain.Events;

public record DosageCreatedEvent(Dosage dosage) : IDomainEvent;

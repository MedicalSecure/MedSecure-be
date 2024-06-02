namespace Medication.Domain.Events;


public record DosageUpdatedEvent(Dosage dosage) : IDomainEvent;

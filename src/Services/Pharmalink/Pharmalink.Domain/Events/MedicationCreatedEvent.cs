namespace Pharmalink.Domain.Events;

public record MedicationCreatedEvent(Medication medication) : IDomainEvent;

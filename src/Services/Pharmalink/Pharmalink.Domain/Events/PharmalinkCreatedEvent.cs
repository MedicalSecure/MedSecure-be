namespace Pharmalink.Domain.Events;

public record MedicationCreatedEvent(Models.Medication medication) : IDomainEvent;

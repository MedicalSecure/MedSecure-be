namespace Medication.Domain.Events;


public record DrugCreatedEvent(Drug drug) : IDomainEvent;

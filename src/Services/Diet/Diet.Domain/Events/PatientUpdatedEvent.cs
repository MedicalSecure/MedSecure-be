namespace Diet.Domain.Events;

public record PatientUpdatedEvent(Patient patient) : IDomainEvent;

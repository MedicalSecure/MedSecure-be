



namespace Visit.Domain.Events;

public record PatientUpdatedEvent(Patient patient) : IDomainEvent;

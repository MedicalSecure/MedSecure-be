
namespace Diet.Domain.Events;

public record PatientCreatedEvent(Patient patient) : IDomainEvent;


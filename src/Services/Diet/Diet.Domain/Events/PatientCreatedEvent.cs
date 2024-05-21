namespace Diet.Domain.Events.RegisterEvents
{
    public record PatientCreatedEvent(Patient patient) : IDomainEvent;
}
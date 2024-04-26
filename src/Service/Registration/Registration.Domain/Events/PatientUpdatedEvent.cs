namespace Registration.Domain.Events
{
    public record PatientUpdatedEvent(Patient patient) : IDomainEvent;

}

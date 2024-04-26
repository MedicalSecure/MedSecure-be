namespace Registration.Domain.Events
{
    public record PatientCreatedEvent(Patient patient) : IDomainEvent;
    
}

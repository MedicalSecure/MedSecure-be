namespace BacPatient.Domain.Events.RegisterEvents
{
    public record PatientUpdatedEvent(Patient patient) : IDomainEvent;
}
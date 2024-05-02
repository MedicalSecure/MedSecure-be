namespace BacPatient.Domain.Events
{
    public record PatientUpdatedEvent(Patient patient) : IDomainEvent;

}

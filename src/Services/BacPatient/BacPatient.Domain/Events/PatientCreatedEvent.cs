
namespace BacPatient.Domain.Events
{
    public record PatientCreatedEvent(Patient patient) : IDomainEvent;
    
}

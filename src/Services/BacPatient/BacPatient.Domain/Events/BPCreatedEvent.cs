
namespace BacPatient.Domain.Events
{
    public record BPCreatedEvent(Models.BacPatient BacPatient) : IDomainEvent;
   
}


namespace BacPatient.Domain.Events
{
    public record BPCreatedEvent(Models.BPModel bp) : IDomainEvent;
   
}

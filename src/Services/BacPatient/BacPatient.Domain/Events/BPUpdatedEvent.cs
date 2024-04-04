
namespace BacPatient.Domain.Events
{
    public record BPUpdatedEvent(Models.BPModel bp) : IDomainEvent;

}

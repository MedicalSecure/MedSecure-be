
namespace BacPatient.Domain.Events
{
    public record BPUpdatedEvent(Models.BacPatient bp) : IDomainEvent;

}

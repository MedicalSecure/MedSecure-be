
namespace BacPatient.Domain.Events.RegisterEvents
{
    public record RegisterCreatedEvent(Register register) : IDomainEvent;
}
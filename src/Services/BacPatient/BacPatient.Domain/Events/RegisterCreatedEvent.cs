
namespace BacPatient.Domain.Events
{
    public record RegisterCreatedEvent(Register register) : IDomainEvent;
 
}

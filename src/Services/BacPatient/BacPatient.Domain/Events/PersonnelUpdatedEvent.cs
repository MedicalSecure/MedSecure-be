
namespace BacPatient.Domain.Events
{

    public record PersonnelUpdatedEvent(Personnel personnel) : IDomainEvent;
}

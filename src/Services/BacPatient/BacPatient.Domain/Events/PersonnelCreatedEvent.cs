

namespace BacPatient.Domain.Events
{
  
    public record PersonnelCreatedEvent(Personnel personnel) : IDomainEvent;
}

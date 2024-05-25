

namespace BacPatient.Domain.Events
{
    public record UnitCareCreatedEvent(Models.UnitCare unitCare) : IDomainEvent;
}

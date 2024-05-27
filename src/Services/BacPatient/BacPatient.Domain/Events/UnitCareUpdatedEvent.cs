
namespace BacPatient.Domain.Events
{

    public record UnitCareUpdatedEvent(Models.UnitCare unitCare) : IDomainEvent;
}

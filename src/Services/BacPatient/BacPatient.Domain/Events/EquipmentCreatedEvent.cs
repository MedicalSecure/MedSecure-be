
namespace BacPatient.Domain.Events
{
    public record EquipmentCreatedEvent(Models.Equipment equipment) : IDomainEvent;
}

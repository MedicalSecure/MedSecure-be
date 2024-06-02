using UnitCare.Domain.Abstractions;

namespace UnitCare.Domain.Events
{
    public record EquipmentUpdatedEvent(Models.Equipment equipment) : IDomainEvent;
}

using UnitCare.Domain.Abstractions;

namespace UnitCare.Domain.Events
{
    public record EquipmentCreatedEvent(Models.Equipment equipment) : IDomainEvent;
}

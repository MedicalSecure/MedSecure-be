namespace Prescription.Domain.Events.UnitCareEvents
{
    public record EquipmentUpdatedEvent(Equipment equipment) : IDomainEvent;
}
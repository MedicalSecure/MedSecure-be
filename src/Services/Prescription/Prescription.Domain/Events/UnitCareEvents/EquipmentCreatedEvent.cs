namespace Prescription.Domain.Events.UnitCareEvents
{
    public record EquipmentCreatedEvent(Equipment equipment) : IDomainEvent;
}
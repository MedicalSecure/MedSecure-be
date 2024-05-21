
namespace Diet.Domain.Events
{
    public record EquipmentUpdatedEvent(Models.Equipment equipment) : IDomainEvent;
}

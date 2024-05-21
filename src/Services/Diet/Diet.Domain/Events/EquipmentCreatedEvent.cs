
namespace Diet.Domain.Events
{
    public record EquipmentCreatedEvent(Models.Equipment equipment) : IDomainEvent;
}

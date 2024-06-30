
namespace Diet.Domain.Events
{

    public record UnitCareUpdatedEvent(Models.UnitCare unitCare) : IDomainEvent;
}

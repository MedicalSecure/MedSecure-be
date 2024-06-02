using UnitCare.Domain.Abstractions;

namespace UnitCare.Domain.Events
{

    public record UnitCareUpdatedEvent(Models.UnitCare unitCare) : IDomainEvent;
}

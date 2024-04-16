
using UnitCare.Domain.Abstractions;

namespace UnitCare.Domain.Events
{
    public record UnitCareCreatedEvent(Models.UnitCare unitCare) : IDomainEvent;
}

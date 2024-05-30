namespace Prescription.Domain.Events.UnitCareEvents
{
    public record UnitCareCreatedEvent(UnitCare unitCare) : IDomainEvent;
}
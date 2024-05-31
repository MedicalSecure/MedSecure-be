namespace Prescription.Domain.Events.UnitCareEvents
{
    public record UnitCareUpdatedEvent(UnitCare unitCare) : IDomainEvent;
}
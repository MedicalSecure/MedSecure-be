namespace Prescription.Domain.Events.UnitCareEvents
{
    public record PersonnelUpdatedEvent(Personnel personnel) : IDomainEvent;
}
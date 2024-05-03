namespace Prescription.Domain.Events.RegisterEvents
{
    public record RegisterUpdatedEvent(Register register) : IDomainEvent;
}
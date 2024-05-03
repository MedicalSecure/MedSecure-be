using Prescription.Domain.Entities;

namespace Prescription.Domain.Events.RegisterEvents
{
    public record RegisterCreatedEvent(Register register) : IDomainEvent;
}
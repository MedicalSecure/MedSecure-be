
namespace Diet.Domain.Events.RegisterEvents
{
    public record RegisterCreatedEvent(Register register) : IDomainEvent;
}
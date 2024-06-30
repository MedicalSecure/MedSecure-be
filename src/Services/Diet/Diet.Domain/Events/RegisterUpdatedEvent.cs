namespace Diet.Domain.Events.RegisterEvents
{
    public record RegisterUpdatedEvent(Register register) : IDomainEvent;
}
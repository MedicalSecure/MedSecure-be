namespace Registration.Domain.Events
{
    public record RegisterUpdatedEvent(Register register) : IDomainEvent;

}

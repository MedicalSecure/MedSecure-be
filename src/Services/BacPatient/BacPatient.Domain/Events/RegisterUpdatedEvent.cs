namespace BacPatient.Domain.Events
{
    public record RegisterUpdatedEvent(Register register) : IDomainEvent;

}

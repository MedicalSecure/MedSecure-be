
namespace Registration.Domain.Events
{
    public record RegisterCreatedEvent(Register register) : IDomainEvent;
 
}

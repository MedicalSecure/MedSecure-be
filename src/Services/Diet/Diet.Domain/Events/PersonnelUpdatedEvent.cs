
namespace Diet.Domain.Events
{

    public record PersonnelUpdatedEvent(Personnel personnel) : IDomainEvent;
}

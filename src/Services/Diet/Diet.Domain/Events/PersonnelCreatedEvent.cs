

namespace Diet.Domain.Events
{
  
    public record PersonnelCreatedEvent(Personnel personnel) : IDomainEvent;
}



namespace Diet.Domain.Events
{
    public record RoomCreatedEvent(Room room) : IDomainEvent;
}

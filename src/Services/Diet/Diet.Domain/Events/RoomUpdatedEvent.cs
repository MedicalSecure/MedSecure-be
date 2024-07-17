

namespace   Diet.Domain.Events
{
    public record RoomUpdatedEvent(Room room) : IDomainEvent;
}

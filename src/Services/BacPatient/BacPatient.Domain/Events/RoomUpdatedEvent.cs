

namespace   BacPatient.Domain.Events
{
    public record RoomUpdatedEvent(Room room) : IDomainEvent;
}



namespace BacPatient.Domain.Events
{
    public record RoomCreatedEvent(Room room) : IDomainEvent;
}


using UnitCare.Domain.Abstractions;
using UnitCare.Domain.Models;

namespace UnitCare.Domain.Events
{
    public record RoomUpdatedEvent(Room room) : IDomainEvent;
}

namespace Prescription.Domain.Events.UnitCareEvents
{
    public record RoomUpdatedEvent(Room room) : IDomainEvent;
}
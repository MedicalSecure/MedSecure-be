namespace Prescription.Domain.Events.UnitCareEvents
{
    public record RoomCreatedEvent(Room room) : IDomainEvent;
}
namespace Waste.Domain.Events;

public record RoomUpdatedEvent(Room Room) : IDomainEvent;

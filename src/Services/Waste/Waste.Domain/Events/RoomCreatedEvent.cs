namespace Waste.Domain.Events;

public record RoomCreatedEvent(Room Room) : IDomainEvent;

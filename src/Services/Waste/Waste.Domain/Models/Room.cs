namespace Waste.Domain.Models;

public class Room : Aggregate<RoomId>
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    public static Room Create(RoomId id, string name, string description)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        var room =  new Room
        {
            Id = id,
            Name = name,
            Description = description
        };

        room.AddDomainEvent(new RoomCreatedEvent(room));

        return room;
    }

    public void Update(string name, string description)
    {
        Name = name;
        Description = description;

        AddDomainEvent(new RoomUpdatedEvent(this));
    }
}
namespace Waste.Domain.Models;

public class Room : Entity<RoomId>
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    public static Room Create(RoomId id, string name, string description)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        return new Room
        {
            Id = id,
            Name = name,
            Description = description
        };
    }
}
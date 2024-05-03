namespace BacPatient.Domain.Models
{
    // Represents a piece of equipment within a room
    public class Equipment : Aggregate<EquipmentId>
    {
        // The name of the equipment
        public string Name { get; set; } = default!;

        // A reference identifier for the equipment
        public string Reference { get; set; } = default!;

        // The ID of the room where the equipment is located
        public RoomId RoomId { get; set; } = default!;

        // Factory method to create a new equipment instance
        public static Equipment Create(EquipmentId id, RoomId roomId, string name, string reference)
        {
            // Create a new equipment instance
            var equipment = new Equipment()
            {
                Id = id,
                Name = name,
                Reference = reference,
                RoomId = roomId,
            };

            // Add a domain event for equipment creation
            equipment.AddDomainEvent(new EquipmentCreatedEvent(equipment));
            return equipment;
        }

        // Update the information of the equipment
        public void Update(string name, RoomId roomId, string reference)
        {
            // Update the properties of the equipment
            Name = name;
            Reference = reference;
            RoomId = roomId;

            // Add a domain event for equipment update
            AddDomainEvent(new EquipmentUpdatedEvent(this));
        }
    }
}

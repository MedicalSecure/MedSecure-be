
namespace BacPatient.Domain.Models
{
    // Represents a piece of equipment within a room
    public class Equipment : Aggregate<EquipmentId>
    {
        public Equipment(EquipmentId Id, Guid RoomId, string Name, string Reference)
        {
            Id = Id;
            RoomId = RoomId;
            this.Name = Name;
            this.Reference = Reference;
        }

        // The name of the equipment
        public string? Name { get; set; } = default!;

        // A reference identifier for the equipment
        public string? Reference { get; set; } = default!;

        // The ID of the room where the equipment is located
        public RoomId? RoomId { get; set; } = default!;
      


        // Factory method to create a new equipment instance

        // Update the information of the equipment
        public Equipment()
        {

        }

        public Equipment(EquipmentId id, string reference)
        {
            Id = id;
            Reference = reference;
        }

        public static Equipment Create(
   EquipmentId id,
  string? reference
         )

        {
            var room = new Equipment()
            {
                Id = id,
              Reference = reference

            };


            return room;
        }
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

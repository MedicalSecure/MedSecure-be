
namespace UnitCare.Domain.Models
{
    public class Equipment : Aggregate<EquipmentId>  
    {
        public string Name { get; set; } = default!;
        public string Reference { get; set; } = default!;
        public RoomId RoomId { get; set; } = default!;

        public static Equipment Create(EquipmentId id, RoomId roomId, string name, string reference)
        {
            var equipment = new Equipment()
            {
                Id = id,
                Name = name,
                Reference = reference,
                RoomId = roomId,
            };

            equipment.AddDomainEvent(new EquipmentCreatedEvent(equipment));
            return equipment;
        }

        public void Update(string name, RoomId roomId, string reference)
        {
            Name = name;
            Reference = reference;
            RoomId = roomId;
            AddDomainEvent(new EquipmentUpdatedEvent(this));
        }
    }
}


namespace BacPatient.Domain.Models
{
    public class Room : Aggregate<ValueObjects.RoomId>
    {
        private readonly List<Equipment?> _equipments= new();
        public IReadOnlyList<Equipment?> Equipments => _equipments.AsReadOnly();
        public UnitCareId? UnitCareId { get; set; } = default!;
        public decimal? RoomNumber { get; set; } = default!;
        public Status? Status { get; set; }

        public static Room Create(
            RoomId id,
            UnitCareId unitCareId,
            decimal roomNumber,
            Status status)
        {
            var room = new Room()
            {
                Id = id,
                UnitCareId = unitCareId,
                RoomNumber = roomNumber,
                Status = status,
            };

            room.AddDomainEvent(new RoomCreatedEvent(room));

            return room;
        }
        // lil bac patient 
        public static Room Create(
      RoomId? id,

      decimal? roomNumber,
      Status? status)
        {
            var room = new Room()
            {
                Id = id,
                RoomNumber = roomNumber,
                Status = status,
            };

            room.AddDomainEvent(new RoomCreatedEvent(room));

            return room;
        }

        public void Update(
            UnitCareId unitCareId,
            decimal roomNumber,
            Status status)
        {
            RoomNumber = roomNumber;
            Status = status;
            UnitCareId =unitCareId;

            AddDomainEvent(new RoomUpdatedEvent(this));
        }

        public void AddEquipment(Equipment equipment)
        {
            if (equipment == null)
                throw new ArgumentNullException(nameof(equipment));

            _equipments.Add(equipment);
        }

        public void RemoveEquipment(EquipmentId equipmentId)
        {
            var roomEquipment = _equipments.FirstOrDefault(p => p.Id == equipmentId);
            if (roomEquipment != null)
            {
                _equipments.Remove(roomEquipment);
            }
        }
    }
}

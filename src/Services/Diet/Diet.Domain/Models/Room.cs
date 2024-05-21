
namespace Diet.Domain.Models
{
    public class Room : Aggregate<ValueObjects.RoomId>
    {
        public Equipment Equipment { get; set; }
        public UnitCareId? UnitCareId { get; set; } = default!;
        public decimal? RoomNumber { get; set; } = default!;
        public Status? Status { get; set; }

      private Room() { }
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
      Status? status ,
      Equipment equipment
            ) 
        
        {
            var room = new Room()
            {
                Id = id,
                RoomNumber = roomNumber,
                Status = status,
                Equipment = equipment

            };

            room.AddDomainEvent(new RoomCreatedEvent(room));

            return room;
        }
        public static Room Create(
decimal? roomNumber,
Status? status)
        {
            var room = new Room()
            {
                Id = RoomId.Of(Guid.NewGuid()),
                RoomNumber = roomNumber,
                Status = status,
            };

            room.AddDomainEvent(new RoomCreatedEvent(room));

            return room;
        }
        //bac patient 
        public Room(RoomId id , decimal? roomNumber, Status? status , Equipment equipment)
        {
            Id = id;
            RoomNumber = roomNumber;
            Status = status;
            Equipment = equipment;
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

    }
}

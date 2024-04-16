

namespace UnitCare.Domain.Models
{
    public class UnitCare : Aggregate<UnitCareId>
    {
        private readonly List<Room> _rooms = new();
        public IReadOnlyList<Room> Rooms => _rooms.AsReadOnly();
        public string Title { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public string Type { get; private set; } = default!;
      

        public static UnitCare Create(
            UnitCareId id,
            string title,
            string description,
            string type)
        {
            var unitCare = new UnitCare()
            {
                Id = id,
                Title = title,
                Description = description,
                Type = type,
            };

            unitCare.AddDomainEvent(new UnitCareCreatedEvent(unitCare));

            return unitCare;
        }

        public void Update(

            string title,
            string description,
            string type)
        {
           
            Title = title;
            Description = description;
            Type = type;

            AddDomainEvent(new UnitCareUpdatedEvent(this));
        }

        public void AddRoom(Room room)
        {
            if (room == null)
                throw new ArgumentNullException(nameof(room));

            _rooms.Add(room);
        }

        public void RemoveMeal(RoomId roomId)
        {
            var roomToRemove = _rooms.FirstOrDefault(meal => meal.Id == roomId);
            if (roomToRemove != null)
            {
                _rooms.Remove(roomToRemove);
            }
        }
    }

}

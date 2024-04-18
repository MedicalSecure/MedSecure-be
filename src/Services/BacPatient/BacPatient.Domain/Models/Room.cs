
namespace BacPatient.Domain.Models
{
    public class Room : Aggregate<RoomId>
    {
        public int number { get; private set; } = default!;
        public Status status { get; private set; } = default!;
        public List<int> Beds { get; private set; } = default!;
        public static Room Create(
            RoomId id,
    int number,
    Status status,
    List<int> beds
)
        {
            var room = new Room()
            {
                Id = id,
                number = number,
                status = status,
                Beds = beds
            };

            return room;
        }

    }

}


namespace BacPatient.Domain.Models
{
    public class Room : Aggregate<RoomId>
    {
        public int number { get; private set; } = default!;
        public Status status { get; private set; } = default!;
        public List<int> Beds { get; private set; } = default!;
    }
}

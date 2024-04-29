﻿
namespace BacPatient.Domain.Models
{
    public class Room : Aggregate<RoomId>
    {
        public int Number { get; private set; } = default!;
        public Status Status { get; private set; } = default!;
        public List<int>? Beds { get; private set; } = default!;
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
                Number = number,
                Status = status,
                Beds = beds
            };

            return room;
        }

    }

}
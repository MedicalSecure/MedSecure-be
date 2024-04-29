namespace BacPatient.Application.Extensions
{
    public static partial class RoomExtensions
    {
        public static IEnumerable<RoomDto> ToRoomDtos(this IEnumerable<Room> rooms)
        {
            return rooms.Select(d => new RoomDto(
                            Id: d.Id.Value,
                            Number:d.Number,
                            Status:d.Status,
                            Beds:d.Beds
                        ));
        }
    }
}

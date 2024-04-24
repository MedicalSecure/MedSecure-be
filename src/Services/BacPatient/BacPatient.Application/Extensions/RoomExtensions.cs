namespace BacPatient.Application.Extensions
{
    public static partial class RoomExtensions
    {
        public static IEnumerable<RoomDto> ToRoomDtos(this IEnumerable<Room> rooms)
        {
            return rooms.Select(d => new RoomDto(
                            Id: d.Id.Value,
                            number:d.number,
                            status:d.status,
                            beds:d.Beds

                       
                        ));
        }
    }
}

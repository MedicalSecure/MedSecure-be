
namespace BacPatient.Application.Dtos;

public record RoomDto(Guid Id,
    int Number,
    Status Status,
    List<int>? Beds);

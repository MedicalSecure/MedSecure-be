
namespace BacPatient.Application.Dtos;

public record RoomDto(Guid Id,
    int number,
    Status status,
    List<int> beds);

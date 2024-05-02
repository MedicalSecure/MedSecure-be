
namespace BacPatient.Application.Dtos;

public record RoomDto(
  Guid id , 
    int Number,
    Status Status,
    List<int>? Beds);

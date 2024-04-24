
namespace BacPatient.Application.Dtos;

public record UnitCareDto(Guid Id,
    string Title,
    string Type,
    string Description,
    Status Status);


namespace BacPatient.Application.Dtos.BacPatientSimpleDto
{   
    public record SimplePatientDto(
        Guid Id,
        string FirstName,
        string? LastName,
        DateTime? DateOfbirth,
        Gender? Gender
        );
}

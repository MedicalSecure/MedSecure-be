
namespace Diet.Application.Dtos
{   
    public record SimplePatientDto(
        Guid Id,
        string FirstName,
        string? LastName,
        DateTime? DateOfbirth,
        Gender? Gender
        );
}

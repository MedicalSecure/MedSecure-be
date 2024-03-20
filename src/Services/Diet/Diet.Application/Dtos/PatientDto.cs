
namespace Diet.Application.Dtos;

public record PatientDto(Guid Id, string FirstName, string LastName, DateTime DateOfBirth, Gender Gender);

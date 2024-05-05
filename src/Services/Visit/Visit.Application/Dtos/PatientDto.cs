
namespace Visit.Application.Dtos;

public record PatientDto(
    Guid Id,
    string FirstName,
    string? LastName,
    DateTime? DateOfBirth,
    int? CIN,
    int? CNAM,
    Gender? Gender,
    int? Height,
    int? Weight,
    Boolean? AddressIsRegisterations,
    Boolean? SaveForNextTime,
    string? Email,
    string? Address1,
    string? Address2,
    ActivityStatus? ActivityStatus,
    Country? Country,
    string? State,
    int? ZipCode,
    FamilyStatus? FamilyStatus,
    Children? Children);



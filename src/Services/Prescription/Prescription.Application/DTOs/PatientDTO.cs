using Prescription.Domain.Entities;
using Prescription.Domain.Enums;

namespace Prescription.Application.DTOs
{
    public record PatientDTO(
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
    Children? Children,
        DateTime CreatedAt,
        string CreatedBy,
        DateTime? LastModified,
        string? LastModifiedBy);
}
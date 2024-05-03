using Prescription.Domain.Entities;
using Prescription.Domain.Enums;

namespace Prescription.Application.DTOs
{
    public record PatientDto(
        Guid Id, string firstName,
        string? lastName,
        DateTime? dateOfbirth,
        int? cin,
        int? cnam,
        Gender? gender,
        int? height,
        int? weight,
        string? email,
        string? address1,
        string? address2,
        Country? country,
        string? state,
        FamilyStatus? familyStatus,
        Children? children);
}
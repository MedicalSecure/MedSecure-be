namespace Medication.Application.Extensions;

public static class ValidationExtensions
{
    public static ICollection<ValidationDto> ToValidationsDto(this IReadOnlyList<Domain.Models.Validation> validations)
    {
        return validations.Select(s => s.ToValidationDto()).ToList();
    }

    public static ValidationDto ToValidationDto(this Validation validation)
    {
        return new ValidationDto(
            Id: validation.Id.Value,
            PrescriptionId: validation.PrescriptionId,
            PharmacistId: validation.PharmacistId ?? Guid.Empty,
            UnitCareJson: validation.UnitCareJson,
            Posologies: validation.Posologies.ToPosologiesDto().ToList(),
            Status: validation.Status,
            Notes: validation.Notes,
            CreatedAt: validation.CreatedAt ?? DateTime.UtcNow,
            PharmacistName: validation.PharmacistName
        );
    }
}
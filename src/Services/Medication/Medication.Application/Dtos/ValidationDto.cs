using Medication.Domain.Enums;

namespace Medication.Application.Dtos
{
    public record ValidationDto(
        Guid Id, 
        Guid PrescriptionId, 
        Guid PharmacistId, 
        string UnitCareJson, 
        List<PosologyDto> Posologies, 
        string? PharmacistName, 
        ValidationStatus Status, 
        string? Notes, 
        DateTime CreatedAt
        );
}
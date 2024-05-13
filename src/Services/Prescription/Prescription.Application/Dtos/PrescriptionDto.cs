using rescription.Application.DTOs;

namespace Prescription.Application.DTOs
{
    public record PrescriptionDto(Guid Id,
        Guid RegisterId,
        Guid DoctorId,
        ICollection<SymptomDto> Symptoms,
        ICollection<DiagnosisDto> Diagnoses,
        ICollection<PosologyDto> Posologies,
        DateTime CreatedAt,
        Guid? UnitCareId = null,
        Guid? DietId = null,
        RegisterDto? Register = null,
        DateTime? LastModified = null,
        string? CreatedBy = null,
        string? LastModifiedBy = null);

    public record PrescriptionCreateDto(
      Guid RegisterId,
      Guid DoctorId,
      ICollection<SymptomDto> Symptoms,
      ICollection<DiagnosisDto> Diagnoses,
      ICollection<PosologyDto> Posologies,
      Guid? UnitCareId = null,
      Guid? DietId = null,
      string? CreatedBy = null);

    public record PosologyDto(Guid Id,
        Guid PrescriptionId,
        Guid MedicationId,
        MedicationDto? Medication,
        DateTime StartDate,
        DateTime? EndDate,
        bool IsPermanent,
        ICollection<CommentsDto> Comments,
        ICollection<DispensesDto> Dispenses);

    public record CommentsDto(Guid Id,
        Guid PosologyId,
        string Label,
        string Content);

    public record DispensesDto(Guid Id,
        Guid PosologyId,
        int Hour,
        Dose? BeforeMeal,
        Dose? AfterMeal);
}
namespace Prescription.Application.DTOs
{
    public record PrescriptionDTO(Guid Id,
        Guid RegisterId,
        Guid DoctorId,
        ICollection<SymptomDTO> Symptoms,
        ICollection<DiagnosisDTO> Diagnoses,
        ICollection<PosologyDTO> Posologies,
        DateTime CreatedAt,
        PrescriptionStatus Status,
        ValidationDto? Validation,
        Guid? BedId = null,
        DietForPrescriptionDTO? Diet = null,
        DateTime? LastModified = null,
        string? CreatedBy = null,
        string? LastModifiedBy = null);

    public record PrescriptionCreateUpdateDto(
      Guid? Id, // Not present while creation, but present while updating!
      Guid RegisterId,
      Guid DoctorId,
      ICollection<SymptomDTO> Symptoms,
      ICollection<DiagnosisDTO> Diagnoses,
      ICollection<PosologyDTO> Posologies,
      UnitCareDTO? UnitCare = null,
      DietForPrescriptionDTO? Diet = null,
      string? CreatedBy = null);

    public record PosologyDTO(Guid Id,
        Guid PrescriptionId,
        Guid MedicationId,
        MedicationDTO? Medication,
        DateTime StartDate,
        DateTime? EndDate,
        bool IsPermanent,
        ICollection<CommentsDTO> Comments,
        ICollection<DispensesDTO> Dispenses);

    public record CommentsDTO(Guid Id,
        Guid PosologyId,
        string Label,
        string Content);

    public record DispensesDTO(Guid Id,
        Guid PosologyId,
        int Hour,
        Dose? BeforeMeal,
        Dose? AfterMeal);

    public record ValidationDto(Guid Id, Guid PharmacistId, Guid PrescriptionId, string? PharmacistName, bool IsValid, string Notes, DateTime CreatedAt);
}
using rescription.Application.DTOs;

namespace Prescription.Application.DTOs
{
    public class PrescriptionDto
    {
        public Guid Id { get; }
        public Guid RegisterId { get; }
        public Guid DoctorId { get; }
        public ICollection<SymptomDto> Symptoms { get; }
        public ICollection<DiagnosisDto> Diagnoses { get; }
        public ICollection<PosologyDto> Posologies { get; }
        public UnitCareId? UnitCareId { get; }
        public DietId? DietId { get; }
        public RegisterDto? Register { get; }
        public DateTime? CreatedAt { get; }
        public DateTime? LastModified { get; }
        public string? CreatedBy { get; }
        public string? LastModifiedBy { get; }

        public PrescriptionDto(
            PrescriptionId id,
            RegisterId registerId,
            DoctorId doctorId,
            ICollection<SymptomDto> symptoms,
            ICollection<DiagnosisDto> diagnoses,
            ICollection<PosologyDto> posologies,
            UnitCareId? unitCareId = null,
            DietId? dietId = null,
            RegisterDto? register = null,
            DateTime? createdAt = null,
            DateTime? lastModified = null,
            string? createdBy = null,
            string? lastModifiedBy = null)
        {
            Id = id.Value;
            RegisterId = registerId.Value;
            DoctorId = doctorId.Value;
            Symptoms = symptoms;
            Diagnoses = diagnoses;
            Posologies = posologies;
            UnitCareId = unitCareId;
            DietId = dietId;
            Register = register;
            CreatedAt = createdAt;
            LastModified = lastModified;
            CreatedBy = createdBy;
            LastModifiedBy = lastModifiedBy;
        }
    }

    public record GetPrescriptionsResult(PaginatedResult<PrescriptionDto> Prescriptions);

    public record PosologyDto(Guid Id,
        Guid PrescriptionId,
        MedicationDto Medication,
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
        Dose BeforeMeal,
        Dose AfterMeal);
}
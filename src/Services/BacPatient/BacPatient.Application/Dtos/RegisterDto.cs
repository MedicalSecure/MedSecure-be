



namespace BacPatient.Application.DTOs
{
    public record RegisterDto
    {
        public Guid Id { get; init; }
        public Guid PatientId { get; init; }
        public PatientDto Patient { get; init; }
        public List<RiskFactorDto>? FamilyMedicalHistory { get; init; }
        public List<RiskFactorDto>? PersonalMedicalHistory { get; init; }
        public List<RiskFactorDto>? Diseases { get; init; }
        public List<RiskFactorDto>? Allergies { get; init; }
        public List<HistoryDto>? History { get; init; }
        public List<TestDto>? Test { get; init; }
        public List<PrescriptionDto>? Prescriptions { get; init; }
    }
}
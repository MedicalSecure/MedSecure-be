



namespace BacPatient.Application.DTOs
{
    public record RegisterDto
    {
        public Guid Id { get; init; }
        public Guid PatientId { get; init; }
        public PatientDto Patient { get; init; }
        public List<RiskFactor>? FamilyMedicalHistory { get; init; }
        public List<RiskFactor>? PersonalMedicalHistory { get; init; }
        public List<RiskFactor>? Diseases { get; init; }
        public List<RiskFactor>? Allergies { get; init; }
        public List<History>? History { get; init; }
        public List<Test>? Test { get; init; }
        public List<PrescriptionDto>? Prescriptions { get; init; }
    }
}
namespace Registration.Application.Dtos
{
    public record RegisterDto
    {
        public Guid Id { get; init; }
        /*:public Guid PatientId { get; init; }*/
        public PatientDto Patient { get; init; }
        public List<RiskFactorDto>? FamilyMedicalHistory { get; init; }
        public List<RiskFactorDto>? PersonalMedicalHistory { get; init; }
        public List<RiskFactorDto>? Diseases { get; init; }
        public List<RiskFactorDto>? Allergies { get; init; }
        public List<HistoryDto>? History { get; init; }
        public List<TestDto>? Test { get; init; }
        public RegisterStatus? Status { get; init; }
        public DateTime? CreatedAt { get; init; }

        public RegisterDto() { }
        public RegisterDto(
           RegisterId id,
           /*PatientId patientId,*/
           PatientDto patient,
           RegisterStatus? status = null,
           List<RiskFactorDto>? familyMedicalHistory = null,
           List<RiskFactorDto>? personalMedicalHistory = null,
           List<RiskFactorDto>? diseases = null,
           List<RiskFactorDto>? allergies = null,
           List<HistoryDto>? history = null,
           List<TestDto>? test = null,
           DateTime? createdAt = null)
        {
            Id = id.Value;
            /*PatientId = patientId.Value;*/
            Patient = patient;
            CreatedAt = createdAt;
            Status = status;
            FamilyMedicalHistory = familyMedicalHistory;
            PersonalMedicalHistory = personalMedicalHistory;
            Diseases = diseases;
            Allergies = allergies;
            History = history;
            Test = test;
        }
    }
}
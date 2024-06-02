namespace Registration.Application.Dtos
{
    public record RegisterDto(Guid? Id,
        PatientDto Patient,
        List<RiskFactorDto>? FamilyMedicalHistory,
        List<RiskFactorDto>? PersonalMedicalHistory,
        List<RiskFactorDto>? Diseases,
        List<RiskFactorDto>? Allergies,
        List<HistoryDto>? History,
        List<TestDto>? Test,
        RegisterStatus? Status,
        DateTime? CreatedAt);
}
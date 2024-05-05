
namespace Registration.Application.Dtos
{
    public record RegisterDto(Guid Id,PatientDto patient, List<RiskFactor> familyHistory, List<RiskFactor> personalHistory, List<RiskFactor> disease, List<RiskFactor> allergy,List<History> history,Test test);
}

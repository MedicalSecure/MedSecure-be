
namespace Registration.Application.Dtos
{
    public record RegisterDto(Guid Id,Guid patientId,Patient patient, List<RiskFactor> familyHistory, List<RiskFactor> personalHistory, List<RiskFactor> disease, List<RiskFactor> allergy);
}

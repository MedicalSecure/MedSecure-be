
namespace BacPatient.Application.Dtos
{
    public record RiskFactorDto(Guid Id, string key, string value, List<RiskFactor> subRiskFactor);
    
}

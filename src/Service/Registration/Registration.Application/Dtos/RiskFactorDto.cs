using Registration.Domain.Models;

namespace Registration.Application.Dtos
{
    public record RiskFactorDto(Guid Id, string key, string value, List<RiskFactor> subRiskFactor);
    
}

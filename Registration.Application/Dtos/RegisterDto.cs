using Registration.Domain.Models;


namespace Registration.Application.Dtos
{
    public record RegisterDto(Guid Id, List<RiskFactor> familyHistory, List<RiskFactor> personalHistory);
}

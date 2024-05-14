

using Registration.Application.Dtos;
using Registration.Domain.Models;

namespace Registration.Application.Extensions
{
    public static partial class RiskFactorExtensions
    {
        public static IEnumerable<RiskFactorDto> ToRiskFactorDto (this IEnumerable<RiskFactor> riskFactors)
        {
            return riskFactors.Select(p => new RiskFactorDto(
                id: p.Id.Value,
                key: p.Key,
                value:p.Value,
                code: p.Code,
                description: p.Description,
                isSelected: p.IsSelected,
                type: p.Type,
                icon: p.Icon,
                subRiskFactors:p.SubRiskFactors?.ToList()
                ));
        }
    }
}

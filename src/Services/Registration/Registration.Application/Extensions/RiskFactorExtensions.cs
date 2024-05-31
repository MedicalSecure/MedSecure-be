using Registration.Application.Dtos;
using Registration.Domain.Models;
using Registration.Domain.ValueObjects;

namespace Registration.Application.Extensions
{
    public static partial class RiskFactorExtensions
    {
        public static IEnumerable<RiskFactorDto> ToRiskFactorDto(this IEnumerable<RiskFactor> riskFactors)
        {
            return riskFactors.Select(p => new RiskFactorDto(
                            Id: p.Id.Value,
                            Key: p.Key,
                            Value: p.Value,
                            Code: p.Code,
                            Description: p.Description,
                            IsSelected: p.IsSelected ?? true,
                            Type: p.Type,
                            Icon: p.Icon,
                            SubRiskFactors: p.SubRiskFactors?.ToRiskFactorDtoFromSubRiskFactor().ToList()
                            ));
        }

        public static IEnumerable<RiskFactorDto> ToRiskFactorDtoFromSubRiskFactor(this IEnumerable<SubRiskFactor> subRiskFactors)
        {
            return subRiskFactors.Select(p => new RiskFactorDto(
                            Id: p.Id.Value,
                            Key: p.Key,
                            Value: p.Value,
                            Code: p.Code,
                            Description: p.Description,
                            IsSelected: p.IsSelected,
                            Type: p.Type,
                            Icon: p.Icon,
                            SubRiskFactors: null
                            ));
        }
    }
}
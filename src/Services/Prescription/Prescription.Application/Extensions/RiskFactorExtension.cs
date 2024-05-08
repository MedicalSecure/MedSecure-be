using Prescription.Domain.Entities.RegisterRoot;
using System.Collections.Generic;

namespace Prescription.Application.Extensions
{
    public static class RiskFactorExtension
    {
        public static IEnumerable<RiskFactorDto> ToRiskFactorDto(this IEnumerable<RiskFactor> riskFactors)
        {
            return riskFactors.Select(p => p.ToRiskFactorDto());
        }

        public static RiskFactorDto ToRiskFactorDto(this RiskFactor riskFactor)
        {
            var dto = new RiskFactorDto(
            Id: riskFactor.Id.Value,
                SubRiskFactor: riskFactor.SubRiskFactor?.ToRiskFactorDto().ToList(),
                RiskFactorParentId: riskFactor.RiskFactorParentId?.Value,
                Key: riskFactor.Key,
                Value: riskFactor.Value,
                Code: riskFactor.Code,
                Description: riskFactor.Description,
                IsSelected: riskFactor.IsSelected,
                Type: riskFactor.Type,
                Icon: riskFactor.Icon
            );
            return dto;
        }
    }
}
using Registration.Domain.Models;
using System.Collections.Generic;

namespace Registration.Application.Dtos
{
    public record RiskFactorDto(Guid Id, string Key, string Value, string? Code, string? Description, bool IsSelected, string? Type, string? Icon, List<RiskFactorDto>? SubRiskFactors);
}
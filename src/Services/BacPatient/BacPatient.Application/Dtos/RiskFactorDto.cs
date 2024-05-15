using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Dtos
{


    public record RiskFactorDto
    {
        public Guid Id { get; init; }
        public string? Key { get; init; }
        public string? Value { get; init; }
        public string? Code { get; init; }
        public string? Description { get; init; }
        public bool IsSelected { get; init; }
        public string? Type { get; init; }
        public string? Icon { get; init; }
        public List<SubRiskFactor>? SubRiskFactors { get; init; }
        public RiskFactorDto() { }
        public RiskFactorDto(
            Guid id,
            string? key,
            string? value,
            string? code,
            string? description,
            bool? isSelected,
            string? type,
            string? icon,
            List<SubRiskFactor>? subRiskFactors)
        {
            Id = id;
            Key = key;
            Value = value;
            Code = code;
            Description = description;
            IsSelected = isSelected.HasValue;
            Type = type;
            Icon = icon;
            SubRiskFactors = subRiskFactors;
        }
    }
}

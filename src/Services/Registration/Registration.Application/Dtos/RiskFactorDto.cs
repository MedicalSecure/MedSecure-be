﻿using Registration.Domain.Models;
using System.Collections.Generic;

namespace Registration.Application.Dtos
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
        public List<RiskFactorDto>? SubRiskFactors { get; init; }
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
            List<RiskFactorDto>? subRiskFactors)
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
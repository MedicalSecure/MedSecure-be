using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Models
{
    public class SubRiskFactor : Aggregate<SubRiskFactorId>
    {
        // Properties
        public string Key { get; private set; } = default!;
        public string Value { get; private set; } = default!;
        public string Code { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public bool IsSelected { get; private set; } = false;
        public string Type { get; private set; } = default!;
        public string Icon { get; private set; } = default!;
        public RiskFactorId RiskFactorId { get; private set; } = default!;

        // Constructor (private to enforce creation through factory method)
        private SubRiskFactor() { }

        // Factory method
        public static SubRiskFactor Create(
            SubRiskFactorId id,
            string key,
            string value,
            string code,
            string description,
            bool isSelected,
            string type,
            string icon,
            RiskFactorId riskFactorId)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));

            var subRiskFactor = new SubRiskFactor
            {
                Id = id,
                Key = key,
                Value = value ?? string.Empty,
                Code = code ?? string.Empty,
                Description = description ?? string.Empty,
                IsSelected = isSelected,
                Type = type ?? string.Empty,
                Icon = icon ?? string.Empty,
                RiskFactorId = riskFactorId
            };

            // You can optionally add a domain event here if needed
            // subRiskFactor.AddDomainEvent(new SubRiskFactorCreatedEvent(subRiskFactor));

            return subRiskFactor;
        }

        // Method to update the sub risk factor
        public void Update(
            string key,
            string value,
            string code,
            string description,
            bool isSelected,
            string type,
            string icon)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));

            Key = key;
            Value = value ?? string.Empty;
            Code = code ?? string.Empty;
            Description = description ?? string.Empty;
            IsSelected = isSelected;
            Type = type ?? string.Empty;
            Icon = icon ?? string.Empty;

            // You can optionally add a domain event here if needed
            // AddDomainEvent(new SubRiskFactorUpdatedEvent(this));
        }
    }
}

namespace Prescription.Domain.Entities.RegisterRoot
{
    public class RiskFactor : Aggregate<Guid>
    {
        public List<RiskFactor> SubRiskFactor { get; set; } = default!;

        //Navigation property can be null
        public RiskFactor? RiskFactorParent { get; set; } = default!;

        public Guid? RiskFactorParentId { get; set; } = default!;

        public Guid? RiskFactorId { get; set; } = default!;

        // public Guid? RegisterId { get; set; } = default!;
        public string Key { get; set; } = default!;

        public string Value { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Boolean IsSelected { get; set; } = false;
        public string Type { get; set; } = default!;
        public string Icon { get; set; } = default!;

        public static RiskFactor Create(Guid id, string key, string value, string code, string description, Boolean isSelected, string type, string icon, List<RiskFactor> subRiskFactor)
        {
            var riskFactor = new RiskFactor
            {
                Key = key,
                Value = value,
                Code = code,
                Description = description,
                IsSelected = isSelected,
                Type = type,
                Icon = icon,
                SubRiskFactor = subRiskFactor
            };
            riskFactor.AddDomainEvent(new RiskFactorCreatedEvent(riskFactor));
            return riskFactor;
        }

        public void Update(string key, string value, string description, Boolean isSelected, string type, string icon, List<RiskFactor> subRiskFactor)
        {
            Key = key;
            Value = value;
            Description = description;
            IsSelected = isSelected;
            Type = type;
            Icon = icon;
            SubRiskFactor = subRiskFactor;
            AddDomainEvent(new RiskFactorUpdatedEvent(this));
        }
    }
}
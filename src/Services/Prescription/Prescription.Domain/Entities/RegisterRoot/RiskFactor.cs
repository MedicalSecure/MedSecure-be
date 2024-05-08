namespace Prescription.Domain.Entities.RegisterRoot
{
    public class RiskFactor : Aggregate<RiskFactorId>
    {
        public List<RiskFactor> SubRiskFactor { get; private set; } = default!;

        //Navigation property can be null
        public RiskFactor? RiskFactorParent { get; private set; } = default!;

        public RiskFactorId? RiskFactorParentId { get; private set; } = default!;

        public string Key { get; private set; } = default!;

        public string Value { get; private set; } = default!;
        public string Code { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public Boolean IsSelected { get; private set; } = false;
        public string Type { get; private set; } = default!;
        public string Icon { get; private set; } = default!;

        public static RiskFactor Create(RiskFactorId id, string key, string value, string code, string description, Boolean isSelected, string type, string icon, List<RiskFactor> subRiskFactor)
        {
            var riskFactor = new RiskFactor
            {
                Id = id,
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

        public static RiskFactor Create( string key, string value, string code, string description, Boolean isSelected, string type, string icon, List<RiskFactor> subRiskFactor)
        {
            var riskFactor = new RiskFactor
            {
                Id = RiskFactorId.Of(Guid.NewGuid()),
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
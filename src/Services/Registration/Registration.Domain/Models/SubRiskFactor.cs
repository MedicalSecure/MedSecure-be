
namespace Registration.Domain.Models
{
    public class SubRiskFactor : Aggregate<SubRiskFactorId>
    {
        public string Key { get; set; } = default!;
        public string Value { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsSelected { get; set; } = false;
        public string Type { get; set; } = default!;
        public string Icon { get; set; } = default!;

        public RiskFactorId RiskFactorId { get; set; } = default!;


        public static RiskFactor Create(RiskFactorId id, string key, string value, string code, string description, Boolean isSelected, string type, string icon)
        {
            var riskFactor = new RiskFactor
            {
                Key = key,
                Value = value,
                Code = code,
                Description = description,
                IsSelected = isSelected,
                Type = type,
                Icon = icon
            };
            riskFactor.AddDomainEvent(new RiskFactorCreatedEvent(riskFactor));
            return riskFactor;
        }
        public void Update(string key, string value, string description, string description1, Boolean isSelected, string type, string icon)
        {
            Key = key;
            Value = value;
            Description = description;
            IsSelected = isSelected;
            Type = type;
            Icon = icon;


            //AddDomainEvent(new SubRiskFactorUpdatedEvent(this));
        }

    }
}

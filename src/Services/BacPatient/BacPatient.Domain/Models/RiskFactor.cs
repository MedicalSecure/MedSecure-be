namespace BacPatient.Domain.Models
{
    public class RiskFactor : Aggregate<RiskFactorId>
    {
        public string Key { get; set; } = default!;
        public string Value { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Boolean IsSelected { get; set; } = false;
        public string Type { get; set; } = default!;
        public string Icon { get; set; } = default!;
        public List<RiskFactor> SubRiskfactory { get; set; } = default!;
        public RegisterId RegisterId { get; set; } = default!;


        public static RiskFactor Create(RiskFactorId id,string key, string value,string code,string description,Boolean isSelected,string type,string icon,List<RiskFactor> subRiskFactor)
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
                SubRiskfactory = subRiskFactor
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
            SubRiskfactory = subRiskFactor;
            AddDomainEvent(new RiskFactorUpdatedEvent(this));
        }

    }
}

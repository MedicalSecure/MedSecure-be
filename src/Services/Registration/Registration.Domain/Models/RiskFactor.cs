namespace Registration.Domain.Models
{
    public class RiskFactor : Aggregate<RiskFactorId>
    {
        public string Key { get; set; } = default!;
        public string Value { get; set; } = default!;
        public List<RiskFactor> SubRiskfactory { get; set; } = default!;

        public RegisterId RegisterId { get; set; } = default!;

        public RiskFactorId RiskFactorId { get; set; } = default!;


        public static RiskFactor Create(RiskFactorId id,string key, string value,List<RiskFactor> subRiskFactor)
        {
            var riskFactor = new RiskFactor
            {
                Key = key,
                Value = value,
                SubRiskfactory = subRiskFactor
            };
            riskFactor.AddDomainEvent(new RiskFactorCreatedEvent(riskFactor));
            return riskFactor;
        }
        public void Update(string key, string value, List<RiskFactor> subRiskFactor)
        {
            Key = Key;
            Value = Value;
            SubRiskfactory = subRiskFactor;
            AddDomainEvent(new RiskFactorUpdatedEvent(this));
        }

    }
}

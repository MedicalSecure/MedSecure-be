


namespace Diet.Domain.Events.RegisterEvents
{
    public record RiskFactorCreatedEvent(RiskFactor riskFactor) : IDomainEvent;
}
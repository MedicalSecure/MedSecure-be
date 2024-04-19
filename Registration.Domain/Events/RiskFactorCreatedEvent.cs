namespace Registration.Domain.Events
{
    public record RiskFactorCreatedEvent(RiskFactor riskFactor) :IDomainEvent;
}

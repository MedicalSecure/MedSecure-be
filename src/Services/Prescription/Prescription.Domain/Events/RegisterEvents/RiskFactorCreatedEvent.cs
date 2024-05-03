namespace Prescription.Domain.Events.RegisterEvents
{
    public record RiskFactorCreatedEvent(RiskFactor riskFactor) : IDomainEvent;
}
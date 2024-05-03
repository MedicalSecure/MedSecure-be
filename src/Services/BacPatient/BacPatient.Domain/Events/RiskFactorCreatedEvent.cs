namespace BacPatient.Domain.Events.RegisterEvents
{
    public record RiskFactorCreatedEvent(RiskFactor riskFactor) : IDomainEvent;
}
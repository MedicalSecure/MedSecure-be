namespace BacPatient.Domain.Events
{
    public record RiskFactorCreatedEvent(RiskFactor riskFactor) :IDomainEvent;
}

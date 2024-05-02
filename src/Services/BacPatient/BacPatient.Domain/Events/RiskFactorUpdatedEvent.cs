namespace BacPatient.Domain.Events
{
    public record RiskFactorUpdatedEvent(RiskFactor riskFactor ) :IDomainEvent;
    
}

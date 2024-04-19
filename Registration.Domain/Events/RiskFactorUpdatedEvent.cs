namespace Registration.Domain.Events
{
    public record RiskFactorUpdatedEvent(RiskFactor riskFactor ) :IDomainEvent;
    
}

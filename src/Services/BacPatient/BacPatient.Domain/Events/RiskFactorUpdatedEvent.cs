﻿namespace BacPatient.Domain.Events.RegisterEvents
{
    public record RiskFactorUpdatedEvent(RiskFactor riskFactor) : IDomainEvent;
}
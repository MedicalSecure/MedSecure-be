namespace Diet.Domain.Events;

public record DietCreatedEvent(Models.Diet diet) : IDomainEvent;

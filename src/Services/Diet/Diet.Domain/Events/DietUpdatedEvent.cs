namespace Diet.Domain.Events;

public record DietUpdatedEvent(Models.Diet diet) : IDomainEvent;

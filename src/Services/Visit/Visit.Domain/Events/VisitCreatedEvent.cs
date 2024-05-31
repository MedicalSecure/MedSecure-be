

namespace Visit.Domain.Events;

public record VisitCreatedEvent(Models.Visit visit) : IDomainEvent;


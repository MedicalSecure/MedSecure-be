
namespace Visit.Domain.Events;
public record VisitUpdtedEvent(Models.Visit visit) : IDomainEvent;


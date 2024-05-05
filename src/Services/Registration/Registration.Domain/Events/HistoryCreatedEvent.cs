
namespace Registration.Domain.Events
{
    public record HistoryCreatedEvent(History history) : IDomainEvent
    {
    }
}

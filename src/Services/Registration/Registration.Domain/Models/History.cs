using System;

namespace Registration.Domain.Models;

public class History : Aggregate<HistoryId>
{
    // Properties
    public DateTime Date { get; private set; }

    public HistoryStatus Status { get; private set; }
    public RegisterId RegisterId { get; private set; } = default!;

    // Constructor (private to enforce creation through factory method)
    public History()
    { }

    // Factory method
    public static History Create(HistoryId id, RegisterId registerId, HistoryStatus? status, DateTime? date = null)
    {
        var history = new History
        {
            Id = id,
            Date = date ?? DateTime.Now,
            Status = status ?? HistoryStatus.Registered,
            RegisterId = registerId
        };
        history.AddDomainEvent(new HistoryCreatedEvent(history));
        return history;
    }

    public static History Create(RegisterId registerId, HistoryStatus? status, DateTime? date = null)
    {
        HistoryId id = HistoryId.Of(Guid.NewGuid());
        var history = new History
        {
            Id = id,
            Date = date ?? DateTime.Now,
            Status = status ?? HistoryStatus.Registered,
            RegisterId = registerId
        };
        history.AddDomainEvent(new HistoryCreatedEvent(history));
        return history;
    }

    // Method to update the history
    public void Update(HistoryId id, RegisterId registerId, HistoryStatus? status, DateTime? date)
    {
        RegisterId = registerId;
        Id = id;
        Date = date ?? DateTime.Now;
        Status = status ?? HistoryStatus.Registered;

        AddDomainEvent(new HistoryUpdatedEvent(this));
    }
}
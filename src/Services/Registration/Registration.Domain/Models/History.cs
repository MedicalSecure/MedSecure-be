using System;

namespace Registration.Domain.Models;

public class History : Aggregate<HistoryId>
{
    // Properties
    public DateTime? Date { get; private set; }
    public Status? Status { get; private set; }
    public RegisterId RegisterId { get; private set; } = default!;

    // Constructor (private to enforce creation through factory method)
    public History() { }

    // Factory method
    public static History Create(HistoryId id,DateTime? date, Status? status, RegisterId registerId)
    {
        var history = new History
        {
            Id = id,
            Date = date,
            Status = status,
            RegisterId = registerId
        };
        history.AddDomainEvent(new HistoryCreatedEvent(history));
        return history;
    }

    // Method to update the history
    public void Update(HistoryId id, DateTime? date, Status? status, RegisterId registerId)
    {
        Id = id;
        Date = date;
        Status = status;
        RegisterId = registerId;

        AddDomainEvent(new HistoryUpdatedEvent(this));
    }
}

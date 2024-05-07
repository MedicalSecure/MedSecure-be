using System;

namespace Registration.Domain.Models;

public class History : Aggregate<HistoryId>
{
    // Properties
    public DateTime Date { get; private set; }
    public Status Status { get; private set; } = Enums.Status.Resident;
    public RegisterId RegisterId { get; private set; } = default!;

    // Constructor (private to enforce creation through factory method)
    private History() { }

    // Factory method
    public static History Create(DateTime date, Status status, RegisterId registerId)
    {
        var history = new History
        {
            Date = date,
            Status = status,
            RegisterId = registerId
        };
        history.AddDomainEvent(new HistoryCreatedEvent(history));
        return history;
    }

    // Method to update the history
    public void Update(DateTime date, Status status, RegisterId registerId)
    {
        Date = date;
        Status = status;
        RegisterId = registerId;

        AddDomainEvent(new HistoryUpdatedEvent(this));
    }
}

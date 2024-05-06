
using Registration.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Domain.Models
{
    public class History:Aggregate<HistoryId>
    {
        public DateTime Date { get; set; }
        public Status Status { get; set; } = Enums.Status.Resident;
        public RegisterId RegisterId { get; set; } = default!;

        public static History Create(DateTime date,Status status, RegisterId registerId)
    {
        var history = new History
        {

            Date = date,
            Status= status,
            RegisterId= registerId,
          
        };
        history.AddDomainEvent(new HistoryCreatedEvent(history));
        return history;
    }
    public void Update(DateTime date,Status status, RegisterId registerId)
    {

        Date = date;
        Status = status;
            RegisterId = registerId;

        AddDomainEvent(new HistoryUpdatedEvent(this));
    }
  }
}



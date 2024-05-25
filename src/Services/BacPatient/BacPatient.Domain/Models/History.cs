namespace BacPatient.Domain.Models.RegisterRoot
{
    public class History : Entity<HistoryId>
    { // Properties
        public DateTime? Date { get; private set; }
        public Status? Status { get; private set; }
        public RegisterId RegisterId { get; private set; } = default!;

        // Constructor (private to enforce creation through factory method)
        public History() { }

        // Factory method
        public static History Create(HistoryId id, DateTime? date, Status? status, RegisterId registerId)
        {
            var history = new History
            {
                Id = id,
                Date = date,
                Status = status,
                RegisterId = registerId
            };
            return history;
        }

        // Method to update the history
        public void Update(HistoryId id, DateTime? date, Status? status, RegisterId registerId)
        {
            Id = id;
            Date = date;
            Status = status;
            RegisterId = registerId;

        }
    }
}
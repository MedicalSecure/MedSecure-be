namespace Prescription.Domain.Entities.RegisterRoot
{
    public class History : Entity<HistoryId>
    {
        public DateTime Date { get; private set; }
        public Status Status { get; private set; } = Status.Resident;
        public RegisterId RegisterId { get; private set; } = default!;

        /*      private History()
              { }*/

        public History()
        { }

        private History(HistoryId id, DateTime date, Status status, RegisterId registerId)
        {
            Id = id;
            Date = date;
            Status = status;
            RegisterId = registerId;
        }

        public static History Create(DateTime date, Status status, RegisterId registerId)
        {
            return new History(HistoryId.Of(Guid.NewGuid()), date, status, registerId);
        }

        public static History Create(HistoryId id, DateTime date, Status status, RegisterId registerId)
        {
            return new History(id, date, status, registerId);
        }
    }
}
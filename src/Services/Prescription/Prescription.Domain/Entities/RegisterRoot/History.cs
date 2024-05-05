namespace Prescription.Domain.Entities.RegisterRoot
{
    public class History : Entity<Guid>
    {
        public DateTime Date { get; private set; }
        public Status Status { get; private set; } = Status.Resident;
        public Guid RegisterId { get; private set; } = default!;

  /*      private History()
        { }*/

        public History()
        { }

        private History(Guid id, DateTime date, Status status, Guid registerId)
        {
            Id = id;
            Date = date;
            Status = status;
            RegisterId = registerId;
        }

        public static History Create(DateTime date, Status status, Guid registerId)
        {
            return new History(Guid.NewGuid(), date, status, registerId);
        }

        public static History Create(Guid id, DateTime date, Status status, Guid registerId)
        {
            return new History(id, date, status, registerId);
        }
    }
}
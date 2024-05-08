namespace Prescription.Domain.Entities.PrescriptionRoot
{
    public class Posology : Entity<PosologyId>
    {
        private readonly List<Comment> _comments = new List<Comment>();
        private readonly List<Dispense> _dispenses = new List<Dispense>();

        public PrescriptionId PrescriptionId { get; private set; }
        public Prescription Prescription { get; set; }
        public MedicationId MedicationId { get; set; }
        public Medication Medication { get; private set; }
        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }
        public bool IsPermanent { get; private set; }

        public IReadOnlyList<Dispense> Dispenses => _dispenses.AsReadOnly();

        public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();

        private Posology()
        {
        }

        private Posology(PosologyId id, PrescriptionId prescriptionId, Medication medication, DateTime startDate, DateTime? endDate, bool isPermanent)
        {
            Id = id;
            PrescriptionId = prescriptionId;
            StartDate = startDate;
            EndDate = endDate;
            IsPermanent = isPermanent;
            Medication = medication;
            MedicationId = medication.Id;
        }

        public static Posology Create(PrescriptionId prescriptionId, Medication medication, DateTime startDate, DateTime? endDate, bool isPermanent)
        {
            if (isPermanent == false && endDate == null) throw new ArgumentNullException("test");
            if (medication == null) throw new ArgumentNullException("test");
            return new Posology(PosologyId.Of(Guid.NewGuid()), prescriptionId, medication, startDate, endDate, isPermanent);
        }

        public static Posology Create(PosologyId id, PrescriptionId prescriptionId, Medication medication, DateTime startDate, DateTime? endDate, bool isPermanent)
        {
            if (isPermanent == false && endDate == null) throw new ArgumentNullException("test");
            if (medication == null) throw new ArgumentNullException("test");
            return new Posology(id, prescriptionId, medication, startDate, endDate, isPermanent);
        }

        public void AddDispense(Dispense dispense)
        {
            // Validate and add dispense
            _dispenses.Add(dispense);
        }

        public void AddComment(Comment comment)
        {
            // Validate and add comment
            _comments.Add(comment);
        }
    }
}
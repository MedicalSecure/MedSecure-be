#pragma warning disable CS8618 // Disable the warning for non-nullable reference types

namespace Prescription.Domain.Entities
{
    public class Posology : Entity<PosologyId>
    {
        private readonly List<Comment> _comments = new List<Comment>();
        private readonly List<Dispense> _dispenses = new List<Dispense>();

        public PrescriptionId PrescriptionId { get; private set; }
        public Prescription? Prescription { get; set; }
        public MedicationId MedicationId { get; set; }
        public Medication? Medication { get; private set; }
        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }
        public bool IsPermanent { get; private set; }

        public IReadOnlyList<Dispense> Dispenses => _dispenses.AsReadOnly();

        public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();

        private Posology()
        {
        }

        private Posology(PosologyId id, PrescriptionId prescriptionId, MedicationId medicationId, Medication? medication, DateTime startDate, DateTime? endDate, bool isPermanent, string createdBy, DateTime createdAt)
        {
            Id = id;
            PrescriptionId = prescriptionId;
            StartDate = startDate;
            EndDate = endDate;
            IsPermanent = isPermanent;
            Medication = medication;
            MedicationId = medicationId;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
        }

        /*        public static Posology Create(PrescriptionId prescriptionId, Medication medication, DateTime startDate, DateTime? endDate, bool isPermanent)
                {
                    if (isPermanent == false && endDate == null) throw new ArgumentNullException("test");
                    return new Posology(PosologyId.Of(Guid.NewGuid()), prescriptionId, medication, startDate, endDate, isPermanent);
                }*/

        public static Posology Create(PrescriptionId prescriptionId, MedicationId medicationId, DateTime startDate, DateTime? endDate, bool isPermanent, string createdBy, DateTime createdAt = default)
        {
            if (isPermanent == false && endDate == null) throw new ArgumentNullException("test");

            var CreatedAt = createdAt == default ? DateTime.Now : createdAt;
            return new Posology(PosologyId.Of(Guid.NewGuid()), prescriptionId, medicationId, null, startDate, endDate, isPermanent, createdBy, CreatedAt);
        }
        public static Posology Create(PrescriptionId prescriptionId, Medication medication, DateTime startDate, DateTime? endDate, bool isPermanent, string createdBy, DateTime createdAt = default)
        {
            if (isPermanent == false && endDate == null) throw new ArgumentNullException("test");

            var CreatedAt = createdAt == default ? DateTime.Now : createdAt;
            return new Posology(PosologyId.Of(Guid.NewGuid()), prescriptionId, medication.Id, medication, startDate, endDate, isPermanent, createdBy, CreatedAt);
        }

        /*        public static Posology Create(PosologyId id, PrescriptionId prescriptionId, Medication medication, DateTime startDate, DateTime? endDate, bool isPermanent)
                {
                    if (isPermanent == false && endDate == null) throw new ArgumentNullException("test");
                    if (medication == null) throw new ArgumentNullException("test");
                    return new Posology(id, prescriptionId, medication, startDate, endDate, isPermanent);
                }*/

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
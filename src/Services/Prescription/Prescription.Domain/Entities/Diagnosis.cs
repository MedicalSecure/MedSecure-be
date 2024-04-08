namespace Prescription.Domain.Entities
{
    public class Diagnosis : Aggregate<Guid>
    {
        public string Name { get; init; }
        public string Description { get; init; }

        public List<PrescriptionEntity> Prescriptions;

        private Diagnosis()
        { } // For EF

        private Diagnosis(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static Diagnosis Create(string name, string description)
        {
            return new Diagnosis(name, description);
        }
    }
}
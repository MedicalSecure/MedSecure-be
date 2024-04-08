namespace Prescription.Domain.Entities
{
    public class Symptom : Aggregate<Guid>
    {
        public string Name { get; init; }
        public string Description { get; init; }

        public List<PrescriptionEntity> Prescriptions;

        private Symptom()
        { } // For EF

        private Symptom(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static Symptom Create(string name, string description)
        {
            return new Symptom(name, description);
        }
    }
}
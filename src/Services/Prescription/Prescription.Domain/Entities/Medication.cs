namespace Prescription.Domain.Entities
{
    public class Medication : Aggregate<Guid>
    {
        private string Description { get; init; }

        private Medication()
        { } // For EF

        private Medication(string description)
        {
            Description = description;
        }

        public static Medication Create(string description)
        {
            return new Medication(description);
        }
    }
}
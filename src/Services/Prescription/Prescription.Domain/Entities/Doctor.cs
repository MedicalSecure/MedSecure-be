namespace Prescription.Domain.Entities
{
    public class Doctor : Aggregate<Guid>
    {
        public string Name { get; init; }

        private Doctor()
        { } // For EF

        public static Doctor Create(string name)
        {
            return new Doctor { Name = name };
        }
    }
}
namespace Prescription.Domain.Entities
{
    public class Patient : Aggregate<Guid>
    {
        public string Name { get; init; }

        private Patient()
        { } // For EF

        public static Patient Create(string name)
        {
            return new Patient { Name = name };
        }
    }
}
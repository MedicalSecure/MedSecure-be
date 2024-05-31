namespace Prescription.Domain.Entities
{
    public class Symptom : Aggregate<SymptomId>
    {
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string ShortDescription { get; private set; } = string.Empty;
        public string LongDescription { get; private set; } = string.Empty;

        public List<Prescription>? Prescriptions;

        private Symptom()
        { } // For EF

        private Symptom(SymptomId id, string code, string name, string shortDescription, string longDescription)
        {
            Id = id;
            Code = code;
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
        }

        public static Symptom Create(string code, string name, string shortDescription, string longDescription)
        {
            return new Symptom(SymptomId.Of(Guid.NewGuid()), code, name, shortDescription, longDescription);
        }

        public static Symptom Create(SymptomId id, string code, string name, string shortDescription, string longDescription)
        {
            return new Symptom(id, code, name, shortDescription, longDescription);
        }

        public void Update(string code, string name, string shortDescription, string longDescription)
        {
            Code = code;
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
        }
    }
}

namespace Diet.Domain.Models
{
    public class Symptom : Aggregate<SymptomId>
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set; }

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
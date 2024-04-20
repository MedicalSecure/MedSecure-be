namespace Prescription.Domain.Entities
{
    public class Symptom : Aggregate<Guid>
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set; }

        public List<PrescriptionEntity> Prescriptions;

        private Symptom()
        { } // For EF

        private Symptom(string code, string name, string shortDescription, string longDescription)
        {
            Code = code;
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
        }

        private Symptom(Guid id, string code, string name, string shortDescription, string longDescription)
        {
            Id = id;
            Code = code;
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
        }

        public static Symptom Create(string code, string name, string shortDescription, string longDescription)
        {
            return new Symptom(code, name, shortDescription, longDescription);
        }

        public static Symptom Create(Guid id, string code, string name, string shortDescription, string longDescription)
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
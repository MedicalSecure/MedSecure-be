namespace Prescription.Domain.Entities
{
    public class Diagnosis : Aggregate<DiagnosisId>
    {
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string ShortDescription { get; private set; } = string.Empty;
        public string LongDescription { get; private set; } = string.Empty;

        public List<Prescription>? Prescriptions;

        public Diagnosis()
        {
        } // For EF and Mapster

        private Diagnosis(string code, string name, string shortDescription, string longDescription)
        {
            Id = DiagnosisId.Of(Guid.NewGuid());
            Code = code;
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
        }

        private Diagnosis(DiagnosisId id, string code, string name, string shortDescription, string longDescription)
        {
            Id = id;
            Code = code;
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
        }

        public static Diagnosis Create(string code, string name, string shortDescription, string longDescription)
        {
            return new Diagnosis(code, name, shortDescription, longDescription);
        }

        public static Diagnosis Create(DiagnosisId id, string code, string name, string shortDescription, string longDescription)
        {
            return new Diagnosis(id, code, name, shortDescription, longDescription);
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

namespace BacPatient.Domain.Models
{
    public class Diagnosis : Aggregate<Guid>
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set; }

        public List<Prescription>? Prescriptions;

        public Diagnosis()
        {
        } // For EF and Mapster

        private Diagnosis(string code, string name, string shortDescription, string longDescription)
        {
            Id = new Guid();
            Code = code;
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
        }

        private Diagnosis(Guid id, string code, string name, string shortDescription, string longDescription)
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

        public static Diagnosis Create(Guid id, string code, string name, string shortDescription, string longDescription)
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


namespace BacPatient.Domain.Models
{

    public class Prescription : Aggregate<Guid>
    {
        private readonly List<Posology> _posology = new();
        private readonly List<Diagnosis> _diagnosis = new();
        private readonly List<Symptom> _symptoms = new();
        public IReadOnlyList<Posology> Posology => _posology.AsReadOnly();
        public IReadOnlyList<Symptom> Symptoms => _symptoms.AsReadOnly();
        public IReadOnlyList<Diagnosis> Diagnosis => _diagnosis.AsReadOnly();
        public Guid RegisterId { get; private set; }
        public Register? Register { get; private set; }
        public Guid DoctorId { get; private set; }

        public Prescription()
        { }// for EF

        private Prescription(Guid id, Guid registerId, Guid doctorId, DateTime createdAt = default)
        {
            Id = id;
            RegisterId = registerId;
            DoctorId = doctorId;
            CreatedBy = doctorId.ToString();
            CreatedAt = createdAt == default ? DateTime.Now : createdAt;
        }

        public static Prescription Create(Guid RegisterId, Guid doctorId, DateTime createdAt = default)
        {
            //validations here
            //..
            //..

            // Newly created prescription
            Guid PrescriptionId = new Guid();
            return new Prescription(PrescriptionId, RegisterId, doctorId, createdAt);
        }

        public static Prescription Create(Guid PrescriptionId, Guid registerId, Guid doctorId, DateTime createdAt = default)
        {
            //validations here
            //..
            //..
            return new Prescription(PrescriptionId, registerId, doctorId, createdAt);
        }
        private Prescription(Guid id, Register register)
        {
            Id = id;
            Register = register;

        }
        public static Prescription Create(Register Register)
        {
            Guid PrescriptionId = new Guid();
            return new Prescription(PrescriptionId, Register);
        }
        public bool addPosology(Posology posology)
        {
            this._posology.Add(posology);
            return true;
        }

        public bool addDiagnosis(Diagnosis diagnosis)
        {
            this._diagnosis.Add(diagnosis);
            return true;
        }

        public bool addDiagnosis(ICollection<Diagnosis> diagnosis)
        {
            foreach (Diagnosis diagnosisItem in diagnosis)
                this._diagnosis.Add(diagnosisItem);
            return true;
        }

        public bool addSymptom(Symptom symptom)
        {
            this._symptoms.Add(symptom);
            return true;
        }

        public bool addSymptoms(ICollection<Symptom> symptoms)
        {
            foreach (Symptom symptom in symptoms)
                this._symptoms.Add(symptom);
            return true;
        }
    }
}
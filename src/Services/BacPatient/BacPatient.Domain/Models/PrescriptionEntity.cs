

namespace BacPatient.Domain.Models.Prescription
{
    public class PrescriptionEntity : Aggregate<Guid>
    {
        private readonly List<Posology> _posology = new();
        private readonly List<Diagnosis> _diagnosis = new();
        private readonly List<Symptom> _symptoms = new();
        private Guid prescriptionId;

        public IReadOnlyList<Posology> Posology => _posology.AsReadOnly();
        public IReadOnlyList<Symptom> Symptoms => _symptoms.AsReadOnly();
        public IReadOnlyList<Diagnosis> Diagnosis => _diagnosis.AsReadOnly();
        public Guid RegisterId { get; private set; }
        public Register? Register { get; private set; }
        public Guid DoctorId { get; private set; }

        public Doctor? Doctor { get; private set; }

        public  PrescriptionEntity()
        { }// for EF

        private PrescriptionEntity(Guid id, Guid registerId, Doctor? D, Guid doctorId, DateTime? createdAt = default)
        {
            Id = id;
            RegisterId = registerId;
            Doctor = D;
            DoctorId = doctorId;
            CreatedBy = doctorId.ToString();
            CreatedAt = createdAt == default ? DateTime.Now : createdAt;
        }
        private PrescriptionEntity(Guid id, Guid registerId, Guid doctorId, DateTime createdAt = default)
        {
            Id = id;
            RegisterId = registerId;
            DoctorId = doctorId;
            CreatedBy = doctorId.ToString();
            CreatedAt = createdAt == default ? DateTime.Now : createdAt;
        }

        public PrescriptionEntity(Guid prescriptionId, Guid registerId, Guid doctorId, DateTime? createdAt)
        {
            this.prescriptionId = prescriptionId;
            RegisterId = registerId;
            DoctorId = doctorId;
            CreatedAt = createdAt;
        }
        public static PrescriptionEntity Create( Guid id , Guid registerId, Guid doctorId, DateTime? createdAt = default)
        {
            Guid PrescriptionId = new Guid();
            return new PrescriptionEntity(PrescriptionId, registerId, doctorId, createdAt);
        }
        public static PrescriptionEntity Create(Guid RegisterId, Doctor doctor, DateTime? createdAt = default)
        {
            Guid PrescriptionId = new Guid();
            return new PrescriptionEntity(PrescriptionId, RegisterId, doctor, doctor.Id, createdAt);
        }

        public static PrescriptionEntity Create(Guid PrescriptionId, Guid registerId, Doctor doctor, DateTime createdAt = default)
        {
            return new PrescriptionEntity(PrescriptionId, registerId, doctor, doctor.Id, createdAt);
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
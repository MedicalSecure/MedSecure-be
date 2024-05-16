namespace Prescription.Domain.Entities
{
    public class Prescription : Aggregate<PrescriptionId>
    {
        private readonly List<Posology> _posology = new();
        private readonly List<Diagnosis> _diagnosis = new();
        private readonly List<Symptom> _symptoms = new();

        public IReadOnlyList<Posology> Posology => _posology.AsReadOnly();
        public IReadOnlyList<Symptom> Symptoms => _symptoms.AsReadOnly();
        public IReadOnlyList<Diagnosis> Diagnosis => _diagnosis.AsReadOnly();

        public UnitCareId? UnitCareId { get; private set; }
        public DietId? DietId { get; private set; }
        public RegisterId RegisterId { get; private set; }
        public DoctorId DoctorId { get; private set; }

        private Prescription()
        { }// for EF

        private Prescription(PrescriptionId id, RegisterId registerId, DoctorId doctorId, UnitCareId? unitCareId = null, DietId? dietId = null, DateTime createdAt = default)
        {
            Id = id;
            RegisterId = registerId;
            DoctorId = doctorId;
            CreatedBy = doctorId.ToString();
            UnitCareId = unitCareId;
            DietId = dietId;
            CreatedAt = createdAt == default ? DateTime.Now : createdAt;
        }

        public static Prescription Create(RegisterId RegisterId, DoctorId doctorId, UnitCareId? unitCareId = null, DietId? dietId = null, DateTime createdAt = default)
        {
            //validations here
            //..
            //..

            // Newly created prescription
            PrescriptionId prescriptionId = PrescriptionId.Of(Guid.NewGuid());
            return new Prescription(prescriptionId, RegisterId, doctorId, unitCareId, dietId, createdAt);
        }

        public static Prescription Create(PrescriptionId PrescriptionId, RegisterId registerId, DoctorId doctorId, UnitCareId? unitCareId = null, DietId? dietId = null, DateTime createdAt = default)
        {
            //validations here
            //..
            //..
            return new Prescription(PrescriptionId, registerId, doctorId, unitCareId, dietId, createdAt);
        }

        public bool addPosology(Posology posology)
        {
            //if (posology.PrescriptionId != Id) return false;
            this._posology.Add(posology);
            return true;
        }

        public bool addDiagnosis(Diagnosis diagnosis)
        {
            this._diagnosis.Add(diagnosis);
            return true;
        }

        public bool addDiagnosis(ICollection<Diagnosis?> diagnosis)
        {
            foreach (Diagnosis diagnosisItem in diagnosis)
            {
                if (diagnosisItem != null)
                    this._diagnosis.Add(diagnosisItem);
            }
            return true;
        }

        public bool addSymptom(Symptom symptom)
        {
            this._symptoms.Add(symptom);
            return true;
        }

        public bool addSymptoms(ICollection<Symptom?> symptoms)
        {
            foreach (Symptom? symptom in symptoms)
            {
                if (symptom != null)
                    this._symptoms.Add(symptom);
            }
            return true;
        }
    }
}
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

        public EquipmentId BedId { get; private set; }
        public DietId? DietId { get; private set; }
        public RegisterId RegisterId { get; private set; }
        public DoctorId DoctorId { get; private set; }

        public PrescriptionStatus Status { get; private set; }

        private Prescription()
        { }// for EF

        private Prescription(PrescriptionId id, RegisterId registerId, DoctorId doctorId, EquipmentId bedId, DietId? dietId = null, PrescriptionStatus status = PrescriptionStatus.Pending)
        {
            Id = id;
            RegisterId = registerId;
            DoctorId = doctorId;
            //CreatedBy = doctorId.ToString();
            BedId = bedId;
            DietId = dietId;
            Status = status;
        }

        public static Prescription Create(RegisterId RegisterId, DoctorId doctorId, EquipmentId bedId, DietId? dietId = null, PrescriptionStatus status = PrescriptionStatus.Pending)
        {
            //validations here
            //..
            //..

            // Newly created prescription
            PrescriptionId prescriptionId = PrescriptionId.Of(Guid.NewGuid());
            return new Prescription(prescriptionId, RegisterId, doctorId, bedId, dietId, status);
        }

        public static Prescription Create(PrescriptionId PrescriptionId, RegisterId registerId, DoctorId doctorId, EquipmentId bedId, DietId? dietId = null, PrescriptionStatus status = PrescriptionStatus.Pending)
        {
            //validations here
            //..
            //..
            return new Prescription(PrescriptionId, registerId, doctorId, bedId, dietId, status);
        }

        private bool _IsReadOnly()
        {
            if (Status == PrescriptionStatus.Draft) return false;
            if (Status == PrescriptionStatus.Pending) return false;

            return true;
        }

        public bool AddPosology(Posology posology)
        {
            if (posology.PrescriptionId != Id) return false;
            if (_IsReadOnly()) return false;

            this._posology.Add(posology);
            return true;
        }

        public bool AddDiagnosis(Diagnosis diagnosis)
        {
            if (_IsReadOnly()) return false;
            this._diagnosis.Add(diagnosis);
            return true;
        }

        public bool AddDiagnosis(ICollection<Diagnosis?> diagnosis)
        {
            if (_IsReadOnly()) return false;
            foreach (Diagnosis diagnosisItem in diagnosis)
            {
                if (diagnosisItem != null)
                    this._diagnosis.Add(diagnosisItem);
            }
            return true;
        }

        public bool AddSymptom(Symptom symptom)
        {
            if (_IsReadOnly()) return false;
            this._symptoms.Add(symptom);
            return true;
        }

        public bool AddSymptoms(ICollection<Symptom?> symptoms)
        {
            if (_IsReadOnly()) return false;

            foreach (Symptom? symptom in symptoms)
            {
                if (symptom != null)
                    this._symptoms.Add(symptom);
            }
            return true;
        }

        public bool UpdateStatus(PrescriptionStatus newStatus)
        {
            if (Status == PrescriptionStatus.Completed || Status == PrescriptionStatus.Discontinued)
            {
                return false;
            }

            if (Status == PrescriptionStatus.Draft)
            {
                var c1 = newStatus == PrescriptionStatus.Draft;
                var c2 = newStatus == PrescriptionStatus.Pending;
                if (c1 || c2)
                {
                    this.Status = newStatus;
                    return true;
                }
                return false;
            }
            if (Status == PrescriptionStatus.Pending)
            {
                var c1 = newStatus == PrescriptionStatus.Rejected;
                var c2 = newStatus == PrescriptionStatus.Active;
                var c3 = newStatus == PrescriptionStatus.Discontinued;
                if (c1 || c2 || c3)
                {
                    this.Status = newStatus;
                    return true;
                }
                return false;
            }
            if (Status == PrescriptionStatus.Rejected)
            {
                var c1 = newStatus == PrescriptionStatus.Pending;
                if (c1)
                {
                    this.Status = newStatus;
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
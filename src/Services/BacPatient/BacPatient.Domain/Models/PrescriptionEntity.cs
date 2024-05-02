using System.Numerics;

namespace BacPatient.Domain.Models
{
    public class PrescriptionEntity : Aggregate<Guid>
    {
        private readonly List<Posology> _posology = new();
        private readonly List<Diagnosis> _diagnosis = new();
        private readonly List<Symptom> _symptoms = new();
        public IReadOnlyList<Posology> Posology => _posology.AsReadOnly();
        public IReadOnlyList<Symptom> Symptoms => _symptoms.AsReadOnly();
        public IReadOnlyList<Diagnosis> Diagnosis => _diagnosis.AsReadOnly();
        public Guid PatientId { get; private set; }
        public Patient? Patient { get; private set; }
        public Guid DoctorId { get; private set; }
        
        public Doctor? Doctor { get; private set; }
        public ICollection<BacPatient> bacPatients { get; private set; }


        private PrescriptionEntity()
        { }// for EF

        private PrescriptionEntity(Guid id, Patient? p, Guid patientId, Doctor? D, Guid doctorId, DateTime createdAt = default)
        {
            Id = id;
            Patient = p;
            PatientId = patientId;
            Doctor = D;
            DoctorId = doctorId;
            CreatedBy = doctorId.ToString();
            CreatedAt = createdAt == default ? DateTime.Now : createdAt;
        }

        public static PrescriptionEntity Create(Patient patient, Doctor doctor, DateTime createdAt = default)
        {
            //validations here
            //..
            //..

            // Newly created prescription
            Guid PrescriptionId = new Guid();
            return new PrescriptionEntity(PrescriptionId, patient, patient.Id, doctor, doctor.Id, createdAt);
        }

        public static PrescriptionEntity Create(Guid PrescriptionId, Patient patient, Doctor doctor, DateTime createdAt = default)
        {
            //validations here
            //..
            //..
            return new PrescriptionEntity(PrescriptionId, patient, patient.Id, doctor, doctor.Id, createdAt);
        }

        public bool addPosology(Posology posology)
        {
            _posology.Add(posology);
            return true;
        }

        public bool addDiagnosis(Diagnosis diagnosis)
        {
            _diagnosis.Add(diagnosis);
            return true;
        }

        public bool addDiagnosis(ICollection<Diagnosis> diagnosis)
        {
            foreach (Diagnosis diagnosisItem in diagnosis)
                _diagnosis.Add(diagnosisItem);
            return true;
        }

        public bool addSymptom(Symptom symptom)
        {
            _symptoms.Add(symptom);
            return true;
        }

        public bool addSymptoms(ICollection<Symptom> symptoms)
        {
            foreach (Symptom symptom in symptoms)
                _symptoms.Add(symptom);
            return true;
        }
    }
}
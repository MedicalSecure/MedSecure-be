using System.Numerics;

namespace Prescription.Domain.Entities.Prescription
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

        private PrescriptionEntity()
        { }// for EF

        private PrescriptionEntity(Guid id, Patient? p, Guid patientId, Doctor? D, Guid doctorId)
        {
            Id = id;
            Patient = p;
            PatientId = patientId;
            Doctor = D;
            DoctorId = doctorId;
        }

        public static PrescriptionEntity Create(Patient patient, Doctor doctor)
        {
            //validations here
            //..
            //..

            // Newly created prescription
            Guid PrescriptionId = new Guid();
            return new PrescriptionEntity(PrescriptionId, patient, patient.Id, doctor, doctor.Id);
        }

        public static PrescriptionEntity Create(Guid PrescriptionId, Patient patient, Doctor doctor)
        {
            //validations here
            //..
            //..
            return new PrescriptionEntity(PrescriptionId, patient, patient.Id, doctor, doctor.Id);
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
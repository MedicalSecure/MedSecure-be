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
        public Patient Patient { get; private set; }
        public Guid DoctorId { get; private set; }

        public Doctor Doctor { get; private set; }

        private PrescriptionEntity()
        { }// for EF

        private PrescriptionEntity(Patient p, Doctor D)
        {
            Patient = p;
            Doctor = D;
        }

        public static PrescriptionEntity Create(Patient patient, Doctor doctor)
        {
            //validations here
            //..
            //..
            return new PrescriptionEntity(patient, doctor);
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

        public bool addSymtom(Symptom symptom)
        {
            this._symptoms.Add(symptom);
            return true;
        }
    }
}
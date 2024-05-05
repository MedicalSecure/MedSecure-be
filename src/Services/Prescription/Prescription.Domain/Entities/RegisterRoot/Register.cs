namespace Prescription.Domain.Entities.RegisterRoot
{
    public class Register : Aggregate<Guid>
    {
        //rename register medical record
        public Patient Patient { get; private set; } = default!;

        public Guid PatientId { get; private set; } = default!;

        public List<RiskFactor> FamilyMedicalHistory { get; private set; } = new();
        public List<RiskFactor> PersonalMedicalHistory { get; private set; } = new();
        public List<RiskFactor> Diseases { get; private set; } = new();
        public List<RiskFactor> Allergies { get; private set; } = new();
        public List<History> History { get; private set; } = new();
        public List<Test> Test { get; private set; } = new();
        public List<PrescriptionRoot.Prescription> Prescriptions { get; private set; } = new();

        public static Register Create(Guid id, Patient patient, List<RiskFactor> familyHistory, List<RiskFactor> personalHistory, List<RiskFactor> disease, List<RiskFactor> allergy, List<History> history, List<PrescriptionRoot.Prescription>? prescriptions, List<Test>? test)
        {
            var register = new Register
            {
                Id = id,
                PatientId = patient.Id,
                Patient = patient,
                FamilyMedicalHistory = familyHistory,
                PersonalMedicalHistory = personalHistory,
                Diseases = disease,
                Allergies = allergy,
                History = history,
                Prescriptions = prescriptions != null ? prescriptions : new List<PrescriptionRoot.Prescription>(),
                Test = test != null ? test : new List<Test>(),
            };
            register.AddDomainEvent(new RegisterCreatedEvent(register));
            return register;
        }

        public void Update(Patient patient, List<RiskFactor> familyHistory, List<RiskFactor> personalHistory, List<RiskFactor> disease, List<RiskFactor> allergy, List<History> history, List<PrescriptionRoot.Prescription>? prescriptions, List<Test>? test)
        {
            Patient = patient;
            PatientId = patient.Id;
            FamilyMedicalHistory = familyHistory;
            PersonalMedicalHistory = personalHistory;
            Diseases = disease;
            Allergies = allergy;
            History = history;
            if (prescriptions != null) Prescriptions = prescriptions;
            if (test != null) Test = test;

            AddDomainEvent(new RegisterUpdatedEvent(this));
        }
    }
}
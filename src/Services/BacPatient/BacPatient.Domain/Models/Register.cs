using BacPatient.Domain.Events.RegisterEvents;

namespace BacPatient.Domain.Models.RegisterRoot
{
    public class Register : Aggregate<Guid>
    {
        //rename register medical record
        public Patient Patient { get; private set; } = default!;

        public Guid? PatientId { get; private set; } = default!;

        public List<RiskFactor>? FamilyMedicalHistory { get; private set; } = default!;
        public List<RiskFactor>? PersonalMedicalHistory { get; private set; } = default!;
        public List<RiskFactor>? Diseases { get; private set; } = default!;
        public List<RiskFactor>? Allergies { get; private set; } = default!;
        public List<History> History { get; private set; } = default!;
        public List<Test>? Test { get; private set; } = default!;

        public List<Prescription>? Prescriptions { get; private set; } = default!;

        public Register() 
        {
        }

        public Register(Guid id, Patient patient, List<Prescription>? prescriptions)
        {
            Id = id;
            Patient = patient;
            Prescriptions = prescriptions;
        }
        public static Register Create( Patient patient , List<Prescription>? prescriptions)
        {
            Guid id = new Guid();
            return new Register(id, patient , prescriptions) ;
        }
        public static Register Create(Guid id, Patient patient, List<RiskFactor> familyHistory, List<RiskFactor> personalHistory, List<RiskFactor> disease, List<RiskFactor> allergy, List<History> history, List<Prescription>? prescriptions, List<Test>? test)
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
                Prescriptions = prescriptions,
                Test = test
            };
            register.AddDomainEvent(new RegisterCreatedEvent(register));
            return register;
        }
      
        public void Update(Patient patient, List<RiskFactor> familyHistory, List<RiskFactor> personalHistory, List<RiskFactor> disease, List<RiskFactor> allergy, List<History> history, List<Prescription>? prescriptions, List<Test>? test)
        {
            Patient = patient;
            PatientId = patient.Id;
            FamilyMedicalHistory = familyHistory;
            PersonalMedicalHistory = personalHistory;
            Diseases = disease;
            Allergies = allergy;
            History = history;
            Prescriptions = prescriptions;
            Test = test;

            AddDomainEvent(new RegisterUpdatedEvent(this));
        }

       
    }
}
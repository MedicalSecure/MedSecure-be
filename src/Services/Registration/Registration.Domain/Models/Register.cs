
namespace Registration.Domain.Models
{
    public class Register : Aggregate<RegisterId>
    {
        //rename register medical record
        public Patient Patient { get; set; } = default!;
        public List<RiskFactor> FamilyMedicalHistory { get; set; } = default!;
        public List<RiskFactor> PersonalMedicalHistory { get; set; } = default!;
        public List<RiskFactor> Disease { get; set; } = default!;
        public List<RiskFactor> Allergy { get; set; } = default!;
        public List<History> History { get; set; } = default!;
        public Test Test { get; set; } = default!;

        public static Register Create(RegisterId id,Patient patient,List<RiskFactor> familyHistory, List<RiskFactor> personalHistory, List<RiskFactor> disease, List<RiskFactor> allergy, List<History> history,Test test)
        {
            var register = new Register
            {               
                
                Patient =patient,
                FamilyMedicalHistory = familyHistory,
                PersonalMedicalHistory = personalHistory,
                Disease = disease,
                Allergy = allergy,
                History= history,
                Test = test
            };
            register.AddDomainEvent(new RegisterCreatedEvent(register));
            return register;
        }
        public void Update(Patient patient,List<RiskFactor> familyHistory, List<RiskFactor> personalHistory ,List<RiskFactor> disease, List<RiskFactor> allergy, List<History> history, Test test)
        {
            
            Patient = patient;
            FamilyMedicalHistory = familyHistory;
            PersonalMedicalHistory = personalHistory;
            Disease = disease;
            Allergy = allergy;
            History = history;
            Test = test;

            AddDomainEvent(new RegisterUpdatedEvent(this));
        }
    }
}

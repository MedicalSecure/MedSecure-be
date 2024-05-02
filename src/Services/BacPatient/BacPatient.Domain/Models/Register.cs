
namespace BacPatient.Domain.Models
{
    public class Register : Aggregate<RegisterId>
    {
        //rename register medical record
        public Room Patient { get; set; } = default!;
        public List<RiskFactor> FamilyMedicalHistory { get; set; } = default!;
        public List<RiskFactor> PersonalMedicalHistory { get; set; } = default!;
        public List<RiskFactor> Disease { get; set; } = default!;
        public List<RiskFactor> Allergy { get; set; } = default!;
        public List<History> History { get; set; } = default!;

        public static Register Create(RegisterId id,Room patient,List<RiskFactor> familyHistory, List<RiskFactor> personalHistory, List<RiskFactor> disease, List<RiskFactor> allergy, List<History> history)
        {
            var register = new Register
            {               
                
                Patient =patient,
                FamilyMedicalHistory = familyHistory,
                PersonalMedicalHistory = personalHistory,
                Disease = disease,
                Allergy = allergy,
                History= history,
            };
            register.AddDomainEvent(new RegisterCreatedEvent(register));
            return register;
        }
        public void Update(Room patient,List<RiskFactor> familyHistory, List<RiskFactor> personalHistory ,List<RiskFactor> disease, List<RiskFactor> allergy, List<History> history)
        {
            
            Patient = patient;
            FamilyMedicalHistory = familyHistory;
            PersonalMedicalHistory = personalHistory;
            Disease = disease;
            Allergy = allergy;
            History = history;

            AddDomainEvent(new RegisterUpdatedEvent(this));
        }
    }
}

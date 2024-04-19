
namespace Registration.Domain.Models
{
    public class Register : Aggregate<RegisterId>
    {
        public List<RiskFactor> Familymedicalhistory { get; set; } = default!;
        public List<RiskFactor> PersonalMedicalHistory { get; set; } = default!;
        public static Register Create(RegisterId id,List<RiskFactor> familyHistory, List<RiskFactor> personalHistory)
        {
            var register = new Register
            {               
                Familymedicalhistory = familyHistory,
                PersonalMedicalHistory = personalHistory
            };
            register.AddDomainEvent(new RegisterCreatedEvent(register));
            return register;
        }
        public void Update(List<RiskFactor> familyHistory, List<RiskFactor> personalHistory)
        {
            Familymedicalhistory = familyHistory;
            PersonalMedicalHistory = personalHistory;

            AddDomainEvent(new RegisterUpdatedEvent(this));
        }
    }
}

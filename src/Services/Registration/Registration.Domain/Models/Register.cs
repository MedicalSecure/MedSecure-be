
namespace Registration.Domain.Models
{
    public class Register : Aggregate<RegisterId>
    {
        public PatientId PatientId { get; set; } = default!;
        public Patient Patient { get; set; } = default!;
        public List<RiskFactor> Familymedicalhistory { get; set; } = default!;
        public List<RiskFactor> PersonalMedicalHistory { get; set; } = default!;
        public List<RiskFactor> Disease { get; set; } = default!;
        public List<RiskFactor> Allergy { get; set; } = default!;
        public static Register Create(RegisterId id,PatientId patientId,Patient patient,List<RiskFactor> familyHistory, List<RiskFactor> personalHistory, List<RiskFactor> disease, List<RiskFactor> allergy)
        {
            var register = new Register
            {               
                PatientId = patientId,
                Patient =patient,
                Familymedicalhistory = familyHistory,
                PersonalMedicalHistory = personalHistory,
                Disease = disease,
                Allergy = allergy
            };
            register.AddDomainEvent(new RegisterCreatedEvent(register));
            return register;
        }
        public void Update(PatientId patientId, Patient patient,List<RiskFactor> familyHistory, List<RiskFactor> personalHistory ,List<RiskFactor> disease, List<RiskFactor> allergy)
        {
            PatientId = patientId;
            Patient = patient;
            Familymedicalhistory = familyHistory;
            PersonalMedicalHistory = personalHistory;
            Disease = disease;
            Allergy = allergy;

            AddDomainEvent(new RegisterUpdatedEvent(this));
        }
    }
}

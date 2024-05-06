
namespace Registration.Domain.Models
{
    public class Register : Aggregate<RegisterId>
    {
        //rename register medical record
        public Patient Patient { get; set; } = default!;

        private readonly List<RiskFactor> _familyMedicalHistory = new();
        public IReadOnlyList<RiskFactor> FamilyMedicalHistory => _familyMedicalHistory.AsReadOnly();
        
        private readonly List<RiskFactor> _personalMedicalHistory = new();
        public IReadOnlyList<RiskFactor> PersonalMedicalHistory => _personalMedicalHistory.AsReadOnly();
        private readonly List<RiskFactor> _disease = new();
        public IReadOnlyList<RiskFactor> Disease => _disease.AsReadOnly();

        private readonly List<RiskFactor> _allergy= new();
        public IReadOnlyList<RiskFactor> Allergy => _allergy.AsReadOnly();

        private readonly List<History> _history = new();
        public IReadOnlyList<History> History => _history.AsReadOnly();
        
        public Test Test { get; set; } = default!;

        public static Register Create(RegisterId id,Patient patient,Test test)
        {
            var register = new Register
            {               
                Patient = patient,
                Test = test
            };
            register.AddDomainEvent(new RegisterCreatedEvent(register));
            return register;
        }
        public void AddFMH(RiskFactor fmh)
        {
            if (fmh == null)
                throw new ArgumentNullException(nameof(fmh));

            _familyMedicalHistory.Add(fmh);
        }  public void AddPMH(RiskFactor pmh)
        {
            if (pmh == null)
                throw new ArgumentNullException(nameof(pmh));

            _personalMedicalHistory.Add(pmh);
        }  
        public void AddDisease(RiskFactor d)
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d));

            _disease.Add(d);
        } 
        public void AddAllergy(RiskFactor A)
        {
            if (A == null)
                throw new ArgumentNullException(nameof(A));

            _allergy.Add(A);
        }
        public void Update(Patient patient, Test test)
        {
            
            Patient = patient;
            Test = test;

            AddDomainEvent(new RegisterUpdatedEvent(this));
        }
    }
}

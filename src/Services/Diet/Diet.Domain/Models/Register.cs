using Diet.Domain.Events.RegisterEvents;

namespace Diet.Domain.Models.RegisterRoot
{
    public class Register : Aggregate<RegisterId>
    {
        // Properties
        public Patient? Patient { get; private set; } = default!;
        public PatientId? PatientId { get; private set; } = default!;

        public IReadOnlyList<Test>? Tests => _tests.AsReadOnly();
        public IReadOnlyList<RiskFactor>? FamilyMedicalHistory => _familyMedicalHistory.AsReadOnly();
        public IReadOnlyList<RiskFactor>? PersonalMedicalHistory => _personalMedicalHistory.AsReadOnly();
        public IReadOnlyList<RiskFactor>? Disease => _disease.AsReadOnly();
        public IReadOnlyList<RiskFactor>? Allergy => _allergy.AsReadOnly();
        public IReadOnlyList<History>? History => _history.AsReadOnly();
        public List<Prescription>? Prescriptions { get; private set; } = default!;

        // Fields
        private readonly List<Test>? _tests = new();
        private readonly List<RiskFactor>? _familyMedicalHistory = new();
        private readonly List<RiskFactor>? _personalMedicalHistory = new();
        private readonly List<RiskFactor>? _disease = new();
        private readonly List<RiskFactor>? _allergy = new();
        private readonly List<History>? _history = new();

        // Constructor
        private Register() { } // Ensure creation through factory method

        // Factory method
        public static Register Create(RegisterId id, Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            var register = new Register
            {
                Id = id,
                Patient = patient
            };
            register.AddDomainEvent(new RegisterCreatedEvent(register));
            return register;
        }

        //bacPatient
        public static Register Create( Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            var register = new Register
            {
                Id =RegisterId.Of(Guid.NewGuid()) ,
                Patient = patient
            };
            register.AddDomainEvent(new RegisterCreatedEvent(register));
            return register;
        }

        // Methods to add medical history, disease, allergy
        public void AddFamilyMedicalHistory(RiskFactor riskFactor)
        {
            if (riskFactor == null)
                throw new ArgumentNullException(nameof(riskFactor));

            _familyMedicalHistory.Add(riskFactor);
        }

        public void AddPersonalMedicalHistory(RiskFactor riskFactor)
        {
            if (riskFactor == null)
                throw new ArgumentNullException(nameof(riskFactor));

            _personalMedicalHistory.Add(riskFactor);
        }

        public void AddDisease(RiskFactor riskFactor)
        {
            if (riskFactor == null)
                throw new ArgumentNullException(nameof(riskFactor));

            _disease.Add(riskFactor);
        }
        public Register(RegisterId id, Patient patient, List<Prescription>? prescriptions)
        {
            Id = id;
            Patient = patient;
            Prescriptions = prescriptions;
        }
        public Register(RegisterId id,  Patient patient)
        {
            Id = id;
            Patient = patient;
        }
        public static Register Create(Patient patient, List<Prescription>? prescriptions)
        {
            RegisterId id = RegisterId.Of(Guid.NewGuid());

            return new Register(id, patient, prescriptions);
        }
        public void AddAllergy(RiskFactor riskFactor)
        {
            if (riskFactor == null)
                throw new ArgumentNullException(nameof(riskFactor));

            _allergy.Add(riskFactor);
        }
        public void AddAllergies(ICollection<RiskFactor> allergy)
        {
            foreach (var al in allergy)
            {
                _allergy.Add(al);
            }
        }
        public void AddDiseases(ICollection<RiskFactor> disease)
        {
            foreach (var dis in disease)
            {
                _disease.Add(dis);
            }
        }

        // Method to update patient and test
        public void Update(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            Patient = patient;

            AddDomainEvent(new RegisterUpdatedEvent(this));
        }
    }
}
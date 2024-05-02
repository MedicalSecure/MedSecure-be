


namespace BacPatient.Domain.Models
{
    public class Patient : Aggregate<Guid>
    {
        public string PatientName { get; private set; } = default!;
        public DateTime DateOfBirth { get; private set; } = default!;
        public Gender Gender { get; private set; } = default!;
        public int Height { get; private set; } = default!;
        public int Weight { get; private set; } = default!;

        public Register? Register { get; set; } = default!;
        public RiskFactor? RiskFactor { get; set; } = default!;
        public RiskFactor? Disease { get; set; } = default!;
        public ICollection<PrescriptionEntity> Prescriptions { get; private set; }
        public ICollection<BacPatient> bacPatient { get; private set; }
        public Patient()
        { } // For EF

        public static Patient Create(Guid id, string patientName, DateTime dateOfbirth, Gender gender, int height, int weight, Register register, RiskFactor riskFactor, RiskFactor disease)
        {
            var patient = new Patient
            {
                Id = id,
                PatientName = patientName,
                DateOfBirth = dateOfbirth,
                Gender = gender,
                Height = height,
                Weight = weight,
                Register = register,
                RiskFactor = riskFactor,
                Disease = disease
            };
            // patient.AddDomainEvent(new PatientCreatedEvent(patient));

            return patient;
        }

        public static Patient Create(string patientName, DateTime dateOfbirth, Gender gender, int height, int weight, Register register, RiskFactor riskFactor, RiskFactor disease)
        {
            var patient = new Patient
            {
                Id = new Guid(),
                PatientName = patientName,
                DateOfBirth = dateOfbirth,
                Gender = gender,
                Height = height,
                Weight = weight,
                Register = register,
                RiskFactor = riskFactor,
                Disease = disease
            };
            // patient.AddDomainEvent(new PatientCreatedEvent(patient));

            return patient;
        }
    }


    public class Register
    {

        public Guid Id { get; set; }
        public List<RiskFactor>? familymedicalhistory { get; set; }
        public List<RiskFactor>? personalMedicalHistory { get; set; }
    }

    public class RiskFactor
    {
        public string? key { get; set; }
        public string? value { get; set; }
        public List<RiskFactor>? subRiskfactory { get; set; }
    }
}
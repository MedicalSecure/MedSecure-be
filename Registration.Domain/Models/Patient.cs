
using Registration.Domain.Enums;
using Registration.Domain.Events;
using Registration.Domain.ValueObjects;

namespace Registration.Domain.Models
{
    public class Patient : Aggregate<PatientId>
    {
        public string PatientName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public int Height { get; set; } = default!;
        public int Weight { get; set; } = default!;
        public Register Register { get; set; } = default!;
        public RiskFactor RiskFactor { get; set; } = default!;
        public RiskFactor Disease { get; set; } = default!;


        public static Patient Create(PatientId id, string patientName, DateTime dateOfbirth, Gender gender, int height, int weight, Register register, RiskFactor riskFactor, RiskFactor disease)
        {
            var patient = new Patient
            {
                PatientName = patientName,
                DateOfBirth = dateOfbirth,
                Gender = gender,
                Height = height,
                Weight = weight,
                Register = register,
                RiskFactor = riskFactor,
                Disease = disease
            };
            patient.AddDomainEvent(new PatientCreatedEvent(patient));

            return patient;
        }
        public void Update(string patientName, DateTime dateOfBirth, Gender gender,int height , int weight, Register register, RiskFactor riskFactor, RiskFactor disease)
        {
            PatientName = patientName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Height = height;
            Weight = weight;
            Register = register;
            RiskFactor = riskFactor;
            Disease = disease;

            AddDomainEvent(new PatientUpdatedEvent(this));
        }
    }
}
